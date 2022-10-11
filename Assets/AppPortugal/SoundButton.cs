using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] public AudioClip sound;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound()
    {
        GetComponent<AudioSource>().PlayOneShot(sound);
    }
}
