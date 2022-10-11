using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BttSoundController : MonoBehaviour
{
    public void PlaySound()
    {
        GameObject.FindGameObjectWithTag("SoundBtt").GetComponent<SoundButton>().PlaySound();
    }
}
