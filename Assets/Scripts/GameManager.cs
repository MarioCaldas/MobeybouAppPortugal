using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Android;

public class GameManager : MonoBehaviour
{
    private const string STORAGE_PERMISSION = "android.permission.READ_EXTERNAL_STORAGE";

    public bool narrations, music, gender; // true = on false = off // gender true= female . false=

    public int language; // 0 english / 1 portuguese

    public bool customNarration;
    public int saveFile; // 1 2 or 3

    public Dataholder dh = new Dataholder();

    [SerializeField] private GameObject boyGO;
    [SerializeField] private GameObject girlGO;

    [SerializeField] public int storyChapterNumber;

    [SerializeField] private GameObject menuAudioSource;

    public Action onStoryMode;
    public Action offStoryMode;

    public bool onStoryModeBool;
    void Awake()
    {
        print("game manager start");
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
            Destroy(gameObject);

        Load();


        Permission.RequestUserPermission(Permission.Microphone);

        onStoryMode += StopMenuMusic;
        offStoryMode += PlayMenuMusic;

    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        bf.Serialize(file, dh);
        file.Close();
    }


    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            dh = (Dataholder)bf.Deserialize(file);
            file.Close();
        }
    }

    private void SetCharacter()
    {
        if(gender)
        {
            boyGO.SetActive(false);
            girlGO.SetActive(true);
        }
        else
        {
            boyGO.SetActive(true);
            girlGO.SetActive(false);
        }
    }

    private bool CheckPermissions()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            return true;
        }

        return AndroidPermissionsManager.IsPermissionGranted(STORAGE_PERMISSION);
    }

    public void OnGrantButtonPress()
    {
        AndroidPermissionsManager.RequestPermission(new[] { STORAGE_PERMISSION }, new AndroidPermissionCallback(
            grantedPermission =>
            {
                Permission.RequestUserPermission(Permission.Microphone);
                // The permission was successfully granted, restart the change avatar routine
            },
            deniedPermission =>
            {
                // The permission was denied
            },
            deniedPermissionAndDontAskAgain =>
            {
                // The permission was denied, and the user has selected "Don't ask again"
                // Show in-game pop-up message stating that the user can change permissions in Android Application Settings
                // if he changes his mind (also required by Google Featuring program)
            }));
    }

    private void StopMenuMusic()
    {
        menuAudioSource.GetComponent<AudioSource>().Pause();

        onStoryModeBool = true;
    }
    private void PlayMenuMusic()
    {
        menuAudioSource.GetComponent<AudioSource>().UnPause();

        onStoryModeBool = false;

        if(FindObjectOfType<PersistentAudioSource2>())
        {
            Destroy(FindObjectOfType<PersistentAudioSource2>().gameObject);
            print("destrou sound");
        }
    }
}
