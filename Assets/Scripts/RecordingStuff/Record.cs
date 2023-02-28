using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
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
        path = Application.persistentDataPath + "/"+FindObjectOfType<GameManager>().saveFile+page+".wav";
        url = "file:///" + path;
        a = new WWW(url);


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
        recording = a.GetAudioClip();
        aS.PlayOneShot(recording);
        yield return null;
    }

    void findMicrophones()
    {
        foreach (var device in Microphone.devices)
        {
            //debug.text = "Name: " + device;
            Debug.Log("Name: " + device);
        }
    }

    public void PlayClip()
    {
        if (!isPlaying)
        {
            StartCoroutine(DeactivatePlayButton());
            isPlaying = true;
            playingImg.sprite = playingOn;
            aS.PlayOneShot(recording);
        }
        else
        {
            StopCoroutine(DeactivatePlayButton());
            isPlaying = false;
            playingImg.sprite = playingOff;
            aS.Stop();
        }
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
    }

    public void Save(int page)//button to save
    {
        SaveWav.Save(FindObjectOfType<GameManager>().saveFile+"Page"+ page, recording);
        panel.SetActive(false);
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
