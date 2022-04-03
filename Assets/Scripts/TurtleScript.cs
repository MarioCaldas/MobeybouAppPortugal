using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gm;
    public GameObject Sand;
    private Audio audioManager;
    public AudioClip laughGirl, laughBoy, click, splashSound;

    void Awake(){
        gm = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<Audio>();
    }


    void OnMouseDown(){
        FindObjectOfType<UI>().glow.SetBool("glow", true);
        StartCoroutine(wait());
        StartCoroutine(splash());
        StartCoroutine(waitToTurn());
        if (gm.gender)
            audioManager.GetComponent<AudioSource>().PlayOneShot(laughGirl);
        else
            audioManager.GetComponent<AudioSource>().PlayOneShot(laughBoy);

        this.GetComponent<Animator>().SetBool("TurtleWalk", true);
        this.GetComponent<InteractionPage3>().SetSurprised();
        Sand.GetComponent<Animator>().SetTrigger("click");
        transform.GetComponent<MeshRenderer>().enabled = true;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.7f);
        audioManager.GetComponent<AudioSource>().PlayOneShot(click);

    }

    IEnumerator splash()
    {
        yield return new WaitForSeconds(8f);
        audioManager.GetComponent<AudioSource>().PlayOneShot(splashSound);

    }

    IEnumerator waitToTurn()
    {
        yield return new WaitForSeconds(4.5f);
        
        GetComponent<InteractionPage3>().character.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        GetComponent<InteractionPage3>().boyCharacter.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }
}
