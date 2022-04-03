using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page6Interaction : MonoBehaviour
{
    public int fruitOnBlender;
    public GameObject character,characterBoy;
    public GameObject blenderType2;
    private GameManager gm;
    private Audio audioManager;
    public AudioClip aCGirl, aCBoy;
    private UI ui;
    private bool playOnce;

    private Animator characterAnim, characterBoyAnim;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<Audio>();
        ui = FindObjectOfType<UI>();

        characterAnim = character.GetComponent<Animator>();
        characterBoyAnim = characterBoy.GetComponent<Animator>();
    }

    void Update()
    {
        if(fruitOnBlender == 12) //if all fruits are in the blender
        {
            if(gm.gender)
                character.GetComponent<Animator>().SetBool("isPage6", true); //ativa a animação da personagem menina
            else
                characterBoy.GetComponent<Animator>().SetBool("isPage6", true);// ativar a animação da personagem menino


            transform.GetComponent<SpriteRenderer>().enabled = false; //desativa a sprite do blender para aparecer o blender com o sumo
            blenderType2.SetActive(true);//ativa o copo com fruta

            StartCoroutine(WaitABit());
            StartCoroutine(RemoveTheCup());
            StartCoroutine(ui.Glow(1));
        }
    }

    IEnumerator WaitABit() //para haver um distanciamento de acontecimentos
    {
        yield return new WaitForSeconds(0.05f);
        if(gm.gender)
            character.GetComponent<MeshRenderer>().enabled = true;
        else
            characterBoy.GetComponent<MeshRenderer>().enabled = true;
    }

    IEnumerator RemoveTheCup() //timer para remover o copo ao mesmo tempo que a animação
    {
        yield return new WaitForSeconds(2.2f);
        blenderType2.transform.GetChild(0).gameObject.SetActive(false);

        if (gm.gender && !playOnce)
        {
            audioManager.GetComponent<AudioSource>().PlayOneShot(aCGirl);
            characterAnim.SetBool("Page6End", true);
        }
        else if (!gm.gender && !playOnce)
        {
            audioManager.GetComponent<AudioSource>().PlayOneShot(aCBoy);
            characterBoyAnim.SetBool("Page6End", true);
        }
            
        playOnce = true;
    }
}
