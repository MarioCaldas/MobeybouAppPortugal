using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    private string device;
    public AudioClip recording;
    public AudioSource aS;
    public bool isRecording;

    public Sprite playingOn, playingOff;
    public Image playingImg;
    public bool isPlaying;

    public Sprite recordingOn, recordingOff;
    public Image recordingImage;

    string path;
    string url;
    WWW a; // to get the audioclip

    public GameObject panel;
    public GameObject fullCanvas;

    public Text debug;
    public Text authorizing;


    //chat gtp save load
    // File name of the audio clip
    public string fileName = "audio.wav";

    // Audio clip to load or save
    private AudioClip audioClip;

    // Path to the persistent data folder
    private string persistentDataPath;

    private void Awake()
    {

        if (!FindObjectOfType<GameManager>().customNarration)
        {
            fullCanvas.SetActive(false);
            this.gameObject.SetActive(false);
        }
        else
        {
            FindObjectOfType<UI>().transform.GetChild(2).gameObject.SetActive(false); //deactivate chapters button
        }

        string page = SceneManager.GetActiveScene().name;

        path = Application.persistentDataPath + "/" + FindObjectOfType<GameManager>().saveFile + page + ".wav";
        url = "file:///" + path;
        a = new WWW(url);

        //print(url);

        //chat gtp save load
        // Get the path to the persistent data folder
        persistentDataPath = Application.persistentDataPath;

        GetComponent<AudioSource>().volume = 1;

        // Load the audio clip from the persistent data folder
        LoadAudioClip();

        // Save the audio clip to the persistent data folder
        //SaveAudioClip();

    }
    //chat gtp save load
    void LoadAudioClip()
    {
        fileName = FindObjectOfType<GameManager>().saveFile + "Page";

        // Combine the file name with the persistent data path
        string filePath = Path.Combine(persistentDataPath, fileName);
        print(fileName);
        // Check if the file exists
        if (File.Exists(filePath))
        {
            // Load the audio clip from the file
            audioClip = WavUtility.ToAudioClip(filePath);

            // Play the audio clip
            GetComponent<AudioSource>().clip = audioClip;
            GetComponent<AudioSource>().volume = 1;

            GetComponent<AudioSource>().Play();
        }
    }

    public void SaveAudioClip()
    {        
        fileName = FindObjectOfType<GameManager>().saveFile + "Page";

        // Combine the file name with the persistent data path
        string filePath= Path.Combine(persistentDataPath, fileName);

        // Convert the audio clip to a WAV file and save it to disk
        if (recording != null)
        {
            byte[] bytes = WavUtility.FromAudioClip(recording);
            File.WriteAllBytes(filePath, bytes);

            print("saved on " + filePath);
        }
    }





    IEnumerator Start()
    {
        findMicrophones();

        yield return Application.RequestUserAuthorization(UserAuthorization.Microphone);

        //if (Application.HasUserAuthorization(UserAuthorization.Microphone))
        //{
        //    authorizing.text = "Microphone found";
        //    Debug.Log("Microphone found");
        //}
        //else
        //{
        //    authorizing.text = "Microphone not found";
        //    Debug.Log("Microphone not found");
        //}
        recordingImage.GetComponent<Button>().interactable = Application.HasUserAuthorization(UserAuthorization.Microphone);
        /*recording = a.GetAudioClip();
        aS.PlayOneShot(recording);*/


        //StartCoroutine(LoadFile(path));
        yield return null;
    }
    private IEnumerator LoadFile(string fullpath)
    {
        print("LOADING CLIP " + fullpath);
        if (!System.IO.File.Exists(fullpath))
        {
            print("DIDN'T EXIST: " + fullpath);
            yield break;
        }

        AudioClip temp = null;
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file://" + fullpath, AudioType.WAV))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                temp = DownloadHandlerAudioClip.GetContent(www);

                print(temp);
            }
        }
        //changeFunction.Invoke(temp);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SaveAudioClip();
        }
    }



    void findMicrophones()
    {
        foreach (var device in Microphone.devices)
        {
            //Debug.Log("Name: " + device);
        }
    }

    public void PlayClip()
    {
        print(isPlaying);
        if (!isPlaying)
        {
            StartCoroutine(DeactivatePlayButton());
            isPlaying = true;
            playingImg.sprite = playingOn;
            aS.PlayOneShot(recording);

            Invoke("ResetIsPlaying", recording.length);
        }
        else
        {
            StopCoroutine(DeactivatePlayButton());
            isPlaying = false;
            playingImg.sprite = playingOff;
            aS.Stop();
        }
    }

    private void ResetIsPlaying()
    {
        isPlaying = false;
    }


    public void StartRecording() // button to start the recording
    {
        if (!isRecording)
        {
            int freq;

            int minf = 0;
            int maxf = 0;

            Microphone.GetDeviceCaps(device, out minf, out maxf);
            if (minf == 0)
            {
                freq = 48000;
            }
            else if (minf <= 48000 && maxf >= 48000)
            {
                freq = 48000;
            }
            else
            {
                freq = maxf;
            }

            recordingImage.sprite = recordingOn;
            recording = Microphone.Start(device, true,300,freq);
            isRecording = true;
        }
        else if(isRecording)
        {
            recordingImage.sprite = recordingOff;
            isRecording = false;         
            panel.SetActive(true);

            //Capture the current clip data
            AudioClip recordedClip = recording;
            var position = Microphone.GetPosition(device);
            var soundData = new float[recordedClip.samples * recordedClip.channels];
            recordedClip.GetData(soundData, 0);

            //Create shortened array for the data that was used for recording
            var newData = new float[position * recordedClip.channels];

            //Copy the used samples to a new array
            for (int i = 0; i < newData.Length; i++)
            {
                newData[i] = soundData[i];
            }

            //One does not simply shorten an AudioClip,
            //    so we make a new one with the appropriate length
            AudioClip newClip = AudioClip.Create(recordedClip.name, position, recordedClip.channels, recordedClip.frequency, false);
            newClip.SetData(newData, 0);        //Give it the data from the old clip
            //Replace the old clip
            AudioClip.Destroy(recordedClip);
            recording = newClip;

        }
        print(recording.length);

    }

    public void Save(int page)//button to save
    {
        /*SaveWav.Save(FindObjectOfType<GameManager>().saveFile+"Page"+ page, recording);
        print("Save: ->"+FindObjectOfType<GameManager>().saveFile + "Page" + page);*/
        panel.SetActive(false);
        SaveAudioClip();
    }

    public void Delete()//delete the save
    {
        File.Delete(path);
        //UnityEditor.AssetDatabase.Refresh();
        panel.SetActive(false);
    }

    IEnumerator DeactivatePlayButton()
    {
        yield return new WaitForSeconds(recording.length);
        playingImg.sprite = playingOff;
    }


}
