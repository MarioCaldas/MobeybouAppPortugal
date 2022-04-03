using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPage8 : MonoBehaviour
{
    public GameObject puff;
    public GameObject character, boyCharacter;
    public Animator characterAnimator;
    public Animator antagonistaAnimator;

    private MeshRenderer mesh;
    private GameManager gm;
    private Audio audioManager;
    public AudioClip click;
    private UI ui;
    private AudioSource aS;
    public AudioClip aCGirl, aCBoy, antagonista;

    void Start()
    {
        aS = GetComponent<AudioSource>();
        audioManager = FindObjectOfType<Audio>();
        gm = FindObjectOfType<GameManager>();
        ui = FindObjectOfType<UI>();

        // set what character it is
        if (gm.gender){
            SetCharacters(character);
            StartCoroutine(WaitToDeliverPano(character.transform));
            character.GetComponent<WalkScript>().walk = true;
        }else{
            SetCharacters(boyCharacter);
            StartCoroutine(WaitToDeliverPano(boyCharacter.transform));
            boyCharacter.GetComponent<WalkScript>().walk = true;
        }

        //set idle for characters
        
        
    }


    private IEnumerator WaitToDeliverPano(Transform positionplayer){

        yield return new  WaitUntil(()=>positionplayer.position.x >= -1.68f);
        yield return new WaitForSecondsRealtime(0.2f);
        antagonistaAnimator.SetBool("deliverpano", true);
        aS.PlayOneShot(antagonista);
    }


    public void ClickOnCharacter()
    {
        //Puff Effect
        puff.GetComponent<ParticleSystem>().Play();
        if (gm.gender)
            aS.PlayOneShot(aCGirl);
        else
            aS.PlayOneShot(aCBoy);

        aS.PlayOneShot(antagonista);

        StartCoroutine(SetSail(0.5f));
    }

    IEnumerator SetSail(float t)
    {
        audioManager.GetComponent<AudioSource>().PlayOneShot(click);

        yield return new WaitForSeconds(0.1f);
        mesh.enabled = false;
        characterAnimator.SetBool("isPage8", false);

        yield return new WaitForSeconds(t);

        //Stop Puff Effect
        puff.GetComponent<ParticleSystem>().Stop();

        yield return new WaitForSeconds(t);

        //Character gets on boat
        character.transform.position = new Vector3(0.6f, -3.83f, -0.15f);
        boyCharacter.transform.position = new Vector3(0.6f, -3.83f, -0.15f);

        mesh.enabled = true;
        yield return new WaitForSeconds(0.5f);
        antagonistaAnimator.SetBool("isSailing", true);

        StartCoroutine(ui.Glow(1));
    }

    private void SetCharacters(GameObject gO)
    {
        gO.SetActive(true);
        mesh = gO.GetComponent<MeshRenderer>();
        characterAnimator = gO.GetComponent<Animator>();
       // gO.transform.position = new Vector3(-3.61f, -2.3f, -0.15f);
    }
}
