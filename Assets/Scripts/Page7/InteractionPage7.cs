using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPage7 : MonoBehaviour
{
    public GameObject character, boyCharacter;
    public Animator characterAnimator;
    public Animator secondaryCharacterAnimator, secondaryGirlCharacterAnimator;
    private GameManager gm;
    private Audio audioManager;
    public AudioClip instrument, danceGirl, danceBoy;
    private UI ui;

    void Start()
    {
        audioManager = FindObjectOfType<Audio>();
        gm = FindObjectOfType<GameManager>();
        ui = FindObjectOfType<UI>();

        if (gm.gender)
        {
            character.gameObject.SetActive(true);
            characterAnimator = character.GetComponent<Animator>();
        }
        else
        {
            boyCharacter.gameObject.SetActive(true);
            characterAnimator = boyCharacter.GetComponent<Animator>();
        }

        /*if (gm.gender)
            secondaryGirlCharacterAnimator.gameObject.SetActive(false);
        else
            secondaryCharacterAnimator.gameObject.SetActive(false);

        characterAnimator.SetBool("berimbauGlow", true);*/
    }

    public void ClickOnCharacter()
    {
        //play music
        audioManager.GetComponent<AudioSource>().PlayOneShot(instrument);
        if(gm.gender)
        audioManager.GetComponent<AudioSource>().PlayOneShot(danceBoy);
        if(!gm.gender)
        audioManager.GetComponent<AudioSource>().PlayOneShot(danceGirl);

        characterAnimator.SetBool("isPlayingInstrument", true);

        secondaryCharacterAnimator.SetBool("isDancing", true);
        secondaryGirlCharacterAnimator.SetBool("isDancing", true);

        StartCoroutine(ui.Glow(2));
    }
}
