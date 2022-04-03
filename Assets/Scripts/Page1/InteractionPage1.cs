using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage1 : MonoBehaviour
{
    public GameObject puff;
    public Animator MapAnimator;
    public AudioSource aS;
    public AudioClip aCMapClick, aCMapOpen;

    private UI ui;

    private void Start()
    {
        ui = FindObjectOfType<UI>();
    }

    public void ClickOnBook()
    {
        //Puff Effect
        puff.GetComponent<ParticleSystem>().Play();

        StartCoroutine(OpenMap(1));

        StartCoroutine(ui.Glow(5f));
    }

    IEnumerator OpenMap(float t)
    {
        yield return new WaitForSeconds(t/2);

        puff.GetComponent<ParticleSystem>().Stop();

        yield return new WaitForSeconds(1.5f);

        MapAnimator.SetBool("ClickOnMap", true);
        aS.PlayOneShot(aCMapClick);
        aS.PlayOneShot(aCMapOpen);
    }
}
