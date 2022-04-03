using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPage10 : MonoBehaviour
{
    public GameObject character, boyCharacter;
    public Animator characterAnimator;
    public Animator animalAnimator;
    public Animator antagonistAnimator;
    private Audio audioManager;
    public GameObject BackGroundNight, sun, moon;

    public AudioClip danceLadrao, danceTartaruga, danceGirl, danceBoy;
    private AudioSource aS;
    private GameManager gm;
    private UI ui;

    void Start()
    {
        aS = GetComponent<AudioSource>();
        audioManager = FindObjectOfType<Audio>();
        gm = FindObjectOfType<GameManager>();
        ui = FindObjectOfType<UI>();

        if (gm.gender)
        {
            character.SetActive(true);
            characterAnimator = character.GetComponent<Animator>();
        }
        else
        {
            boyCharacter.SetActive(true);
            characterAnimator = boyCharacter.GetComponent<Animator>();
        }

        characterAnimator.SetBool("isDancing", true);
        animalAnimator.SetBool("TurtleDance", true);
        antagonistAnimator.SetBool("AntagonistaDance",true);
        //animalAnimator.SetBool("isIdle", true);

        StartCoroutine(Som());
    }

    public void ClickOnCharacter()
    {
        //play music
        aS.Play();
        audioManager.GetComponent<AudioSource>().PlayOneShot(danceLadrao);
        audioManager.GetComponent<AudioSource>().PlayOneShot(danceTartaruga);

        if(gm.gender)
            audioManager.GetComponent<AudioSource>().PlayOneShot(danceGirl);
        else
            audioManager.GetComponent<AudioSource>().PlayOneShot(danceBoy);

        characterAnimator.SetBool("isDancing", true);
        animalAnimator.SetBool("isDancing", true);
        antagonistAnimator.SetBool("isDancing", true);

        StartCoroutine(ui.Glow(3f));
    }


    public void ClickOnScreen(){
        FindObjectOfType<UI>().glow.SetBool("glow", true);
        BackGroundNight.GetComponent<Animator>().SetTrigger("click");


        if (BackGroundNight.GetComponent<Animator>().GetBool("sun"))
        {
            BackGroundNight.GetComponent<Animator>().SetBool("sun", false);
            sun.SetActive(false);
            moon.SetActive(true);
        }
        else if (!BackGroundNight.GetComponent<Animator>().GetBool("sun"))
        {
            BackGroundNight.GetComponent<Animator>().SetBool("sun", true);
            sun.SetActive(true);
            moon.SetActive(false);
        }
    }


    IEnumerator Som()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            if (gm.gender)
                aS.PlayOneShot(danceGirl);
            else
                aS.PlayOneShot(danceBoy);
            yield return new WaitForSeconds(2f);
                aS.PlayOneShot(danceTartaruga);
            yield return new WaitForSeconds(2f);
                aS.PlayOneShot(danceLadrao);
        }
    }

    //IEnumerator ladraoSom()
    //{
    //    yield return new WaitForSeconds(2f);
    //    aS.PlayOneShot(danceLadrao);
    //}

    //IEnumerator characterSom()
    //{
    //    yield return new WaitForSeconds(2f);
    //    if(gm.gender)
    //        aS.PlayOneShot(danceGirl);
    //    else
    //        aS.PlayOneShot(danceBoy);
    //}
}
