using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarPlayer : MonoBehaviour
{
    [SerializeField] public bool clicked;

    [SerializeField] private GuitarPlayController controller;

    [SerializeField] private int id;

    private void OnMouseDown()
    {
        clicked = true;

        if(id == 0)
        {
            controller.boyPlaying = true;
            controller.girlPlaying = false;
            controller.AngolaBoyPlaying = false;

        }
        else if(id == 1)
        {
            controller.boyPlaying = false;
            controller.girlPlaying = true;
            controller.AngolaBoyPlaying = false;
        }
        else if (id == 2)
        {
            controller.boyPlaying = false;
            controller.girlPlaying = false;
            controller.AngolaBoyPlaying = true;
        }

        controller.UpdatePlayer();
    }
}
