using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableOption : MonoBehaviour
{
    [SerializeField] private GameObject sprite;

    [SerializeField] private Dragble dragble;

    public bool inPlace;

    public Vector3 finalPos;

    private void OnMouseDown()
    {
        if(!inPlace)
        {
            dragble.currentDrag = sprite;
            dragble.currentDragScript = this;
        }
    }

    private void OnMouseUp()
    {
        //if (!inPlace)
           // dragble.currentDrag = null;
    }
}
