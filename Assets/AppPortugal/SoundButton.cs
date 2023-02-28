using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] public AudioClip sound;
    private static SoundButton instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound()
    {
        GetComponent<AudioSource>().PlayOneShot(sound);
    }
}
