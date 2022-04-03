using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPage11 : MonoBehaviour
{
    public GameObject angola;
    public GameObject caboVerde;
    public GameObject germany;
    public GameObject india;
    public GameObject portugal;
    public GameObject turkey;
    public GameObject end;

    private Animator angolaAnim;
    private Animator caboVerdeAnim;
    private Animator germanyAnim;
    private Animator indiaAnim;
    private Animator turkeyAnim;
    private Animator portugalAnim;
    private Animator endAnim;

    private Animator txt;

    public bool gender;
    public GameManager gm;
    private UI ui;

    private Audio audioManager;
    public AudioClip aCElephant;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        ui = FindObjectOfType<UI>();
        audioManager = FindObjectOfType<Audio>();

        if (gm.gender != gender)
            transform.gameObject.SetActive(false);

        txt = FindObjectOfType<Text>().gameObject.GetComponent<Animator>();

        angola.GetComponent<Renderer>().enabled = false;
        caboVerde.GetComponent<Renderer>().enabled = false;
        germany.GetComponent<Renderer>().enabled = false;
        india.GetComponent<Renderer>().enabled = false;
        portugal.GetComponent<Renderer>().enabled = false;
        turkey.GetComponent<Renderer>().enabled = false;
        end.GetComponent<Renderer>().enabled = false;

        angolaAnim = angola.GetComponent<Animator>();
        caboVerdeAnim = caboVerde.GetComponent<Animator>();
        germanyAnim = germany.GetComponent<Animator>();
        indiaAnim = india.GetComponent<Animator>();
        portugalAnim = portugal.GetComponent<Animator>();
        turkeyAnim = turkey.GetComponent<Animator>();
        endAnim = end.GetComponent<Animator>();

        if (gm.gender == gender)
        StartCoroutine(Wait(0.5f));
    }

    IEnumerator Wait(float time)
    {
        angola.GetComponent<Renderer>().enabled = true;
        angolaAnim.SetBool("start", true);

        yield return new WaitForSeconds(time);
        caboVerde.GetComponent<Renderer>().enabled = true;
        caboVerdeAnim.SetBool("start", true);
      
        yield return new WaitForSeconds(time);
        germany.GetComponent<Renderer>().enabled = true;
        germanyAnim.SetBool("start", true);
        
        yield return new WaitForSeconds(time);
        india.GetComponent<Renderer>().enabled = true;
        indiaAnim.SetBool("start", true);

        yield return new WaitForSeconds(time);
        portugal.GetComponent<Renderer>().enabled = true;
        portugalAnim.SetBool("start", true);       

        yield return new WaitForSeconds(time);
        turkey.GetComponent<Renderer>().enabled = true;
        turkeyAnim.SetBool("start", true);

        yield return new WaitForSeconds(5);
        angolaAnim.SetBool("fade", true);
        caboVerdeAnim.SetBool("fade", true);
        germanyAnim.SetBool("fade", true);
        indiaAnim.SetBool("fade", true);
        portugalAnim.SetBool("fade", true);
        turkeyAnim.SetBool("fade", true);

        //Hide text
        txt.SetBool("fade", true);

        yield return new WaitForSeconds(time * 3);

        if (gm.language == 1)
            endAnim.SetBool("endPT", true);
        else
            endAnim.SetBool("endEN", true);

        yield return new WaitForSeconds(time * 3);

        //Play Elephant Sound
        audioManager.GetComponent<AudioSource>().PlayOneShot(aCElephant);

        yield return new WaitForSeconds(0.2f);
        end.GetComponent<Renderer>().enabled = true;

        StartCoroutine(ui.Glow(2f));
    }
}
