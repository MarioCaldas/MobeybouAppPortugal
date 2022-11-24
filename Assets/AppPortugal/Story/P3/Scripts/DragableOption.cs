using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableOption : MonoBehaviour
{
    [SerializeField] private GameObject sprite;

    [SerializeField] private Dragble dragble;

    public bool inPlace;

    public Vector3 finalPos;

    public Glower glow;

    private Vector3 initPos;


    private void Start()
    {
        initPos = sprite.transform.position;
    }

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
        if (!inPlace)
        {
            dragble.currentDrag = null;
            sprite.transform.position = initPos;
        }
    }
}
