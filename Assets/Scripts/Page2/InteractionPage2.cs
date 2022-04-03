using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage2 : MonoBehaviour
{
    [SerializeField]
    private GameObject puff;

    public Animator volcanoAnimator;
    public Animator characterAnimator, characterBoyAnimator;

    public AudioSource audioRepeat, audioEffects; //object that has the script Audio
    public AudioClip clickClip, girlLaugh, boyLaugh;

    public GameManager gm;

    public bool touched;
    public GameObject glowing;
    private UI ui;

    void Start()
    {
        ui = FindObjectOfType<UI>();
        gm = FindObjectOfType<GameManager>();

        if (gm.gender)
            characterAnimator.gameObject.SetActive(true);
        else
            characterBoyAnimator.gameObject.SetActive(true);
    }

    public void OnMouseDown()
    {
        print("On Mouse Down: ");
        //volcanoAnimator.SetBool("Volcano_eruption", true);
        ClickOnvolcano();

    }


    public void ClickOnvolcano()
    {
        touched = true;
        characterAnimator.SetTrigger("suprised");
        characterBoyAnimator.SetTrigger("suprised");
        StartCoroutine(Picnic(0.01f));
    }

    IEnumerator Picnic(float t)
    {
        yield return new WaitForSeconds(t);

        //Open Picnic
        audioRepeat.GetComponent<AudioSource>().Play();

        //Stop Puff Effect
        //puff.GetComponent<ParticleSystem>().Stop();
        //puff.SetActive(false);
        glowing.SetActive(true);
        volcanoAnimator.SetBool("Volcano_Eruption", true);
        //Girl Laughing
        characterAnimator.SetBool("isLaughing", true);
        characterAnimator.SetBool("isIdle", false);

        //Boy Laughing
        characterBoyAnimator.SetBool("isLaughing", true);
        characterBoyAnimator.SetBool("isIdle", false);

        if (gm.gender)
            audioEffects.GetComponent<AudioSource>().PlayOneShot(girlLaugh);
        else
            audioEffects.GetComponent<AudioSource>().PlayOneShot(boyLaugh);

        

        yield return new WaitForSeconds(t);

        characterBoyAnimator.SetBool("isLaughing", false);
        characterBoyAnimator.SetBool("isIdle", true);
        characterAnimator.SetBool("isLaughing", false);
        characterAnimator.SetBool("isIdle", true);
        volcanoAnimator.SetBool("Volcano_Eruption", false);
    }


}
