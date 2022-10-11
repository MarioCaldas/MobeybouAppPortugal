using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarPlayer : MonoBehaviour
{
    [SerializeField] public bool clicked;

    [SerializeField] private GuitarPlayController controller;

    [SerializeField] private int id;

    [SerializeField] private InteractionPage7Pt interactionPage;

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
                interactionPage.aS.PlayOneShot(interactionPage.girlLaught1);
                interactionPage.aS.PlayOneShot(interactionPage.boyOnRight1);
            }
            else
            {
                interactionPage.aS.PlayOneShot(interactionPage.girlLaught2);
                interactionPage.aS.PlayOneShot(interactionPage.boyOnRight2);
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
                interactionPage.aS.PlayOneShot(interactionPage.boyLaught1);
                interactionPage.aS.PlayOneShot(interactionPage.boyOnRight1);
            }
            else
            {
                interactionPage.aS.PlayOneShot(interactionPage.boyLaught2);
                interactionPage.aS.PlayOneShot(interactionPage.boyOnRight2);
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
                interactionPage.aS.PlayOneShot(interactionPage.girlLaught1);
                interactionPage.aS.PlayOneShot(interactionPage.boyLaught1);
            }
            else
            {
                interactionPage.aS.PlayOneShot(interactionPage.girlLaught2);
                interactionPage.aS.PlayOneShot(interactionPage.boyLaught2);
            }
        }

        controller.UpdatePlayer();
    }

    public void LaughtsSound()
    {

        int rand = Random.Range(0, 1);

        if(rand == 0)
        {
            interactionPage.aS.PlayOneShot(interactionPage.girlLaught1);
        }
        else
        {
            interactionPage.aS.PlayOneShot(interactionPage.girlLaught2);

        }



    }
}
