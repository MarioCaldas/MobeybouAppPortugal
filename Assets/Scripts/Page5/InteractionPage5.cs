using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage5 : MonoBehaviour
{
    public Animator BushController;
    public Animator characterController, characterBoyController; //first one is for the girl, the second for the boy
    public GameObject CapeVerdeAnimal;
    private GameManager gm;
    private Audio audioManager;
    public AudioClip girl, boy;

    private UI ui;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<Audio>();
        ui = FindObjectOfType<UI>();

        if (gm.gender){
            characterController.gameObject.SetActive(true);
            characterController.SetBool("idleInstrument", true);
            characterController.SetBool("page5", true);
        }
        else{
            characterBoyController.gameObject.SetActive(true);
            characterBoyController.SetBool("idleInstrument", true);
            characterBoyController.SetBool("page5", true);
        }


        
        
    }

    public void ClickOnBush()
    {

        FindObjectOfType<UI>().glow.SetBool("glow", true);
        //bush click
        if (gm.gender)
            audioManager.GetComponent<AudioSource>().PlayOneShot(girl);
        else
            audioManager.GetComponent<AudioSource>().PlayOneShot(boy);

        BushController.SetBool("ClickBush", true);
        characterBoyController.SetBool("isPage5", true);
        characterController.SetBool("isPage5", true);
        CapeVerdeAnimal.SetActive(true);

        StartCoroutine(Wait());

        StartCoroutine(ui.Glow(4));
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        characterBoyController.SetBool("isPage5", false);
        characterController.SetBool("isPage5", false);
    }

    public void CLickLeftSide(){
        print("Left side clicked");
    }

    public void ClickRightSide(){
        print("Right Side Clicked");
    }
}
