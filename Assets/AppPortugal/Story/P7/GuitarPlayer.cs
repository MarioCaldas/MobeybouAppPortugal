using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarPlayer : MonoBehaviour
{
    [SerializeField] public bool clicked;

    [SerializeField] private GuitarPlayController controller;

    [SerializeField] private int id;

    [SerializeField] private InteractionPage7Pt interactionPage;

    [Header("Audio")]
    [SerializeField] public AudioClip laught1, laught2;

    private void Start()
    {
        GetComponentInChildren<Animator>().SetTrigger("glow");
    }

    private void OnMouseDown()
    {
        clicked = true;

        if(id == 0)
        {
            controller.boyPlaying = true;
            controller.girlPlaying = false;
            controller.AngolaBoyPlaying = false;

            int rand = Random.Range(0, 1);
            if (rand == 0)
            {
                interactionPage.aS.PlayOneShot(laught1);
            }
            else
            {
                interactionPage.aS.PlayOneShot(laught2);
            }



        }
        else if(id == 1)
        {
            controller.boyPlaying = false;
            controller.girlPlaying = true;
            controller.AngolaBoyPlaying = false;

            int rand = Random.Range(0, 1);
            if (rand == 0)
            {
                interactionPage.aS.PlayOneShot(laught1);
            }
            else
            {
                interactionPage.aS.PlayOneShot(laught2);
            }


        }
        else if (id == 2)
        {
            controller.boyPlaying = false;
            controller.girlPlaying = false;
            controller.AngolaBoyPlaying = true;

            int rand = Random.Range(0, 1);
            if (rand == 0)
            {
                interactionPage.aS.PlayOneShot(laught1);
            }
            else
            {
                interactionPage.aS.PlayOneShot(laught2);
            }

        }

        controller.UpdatePlayer();

        GetComponentInChildren<Animator>().ResetTrigger("glow");
        //GetComponentInChildren<Animator>().SetTrigger("isIdle");

    }


}
