using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    [SerializeField] public bool clicked;



    private void OnMouseDown()
    {
        clicked = true;
    }
}
