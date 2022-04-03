using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage4 : MonoBehaviour
{
    private UI ui;
    public Animator fadeAnim;

    private Audio audioManager; //object that has the Audio script
    public AudioClip ambientSound;

    void Start()
    {
        ui = FindObjectOfType<UI>();
        audioManager = FindObjectOfType<Audio>();

        StartCoroutine(ui.Glow(15));
        StartCoroutine(Wait(15));

        //play music
        audioManager.GetComponent<AudioSource>().PlayOneShot(ambientSound);
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        fadeAnim.SetBool("fade", true);
    }
}
