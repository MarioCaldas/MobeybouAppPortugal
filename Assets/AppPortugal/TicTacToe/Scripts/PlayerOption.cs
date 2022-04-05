using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOption : MonoBehaviour
{
    [SerializeField]GameStateController gameController;

    private Vector3 initPos;

    public bool dragging;

    public bool interactable;

    private void Start()
    {
        initPos = transform.position;

    }

    public void OnMouseUp()
    {
        if(interactable)
        {
            dragging = false;

            transform.position = initPos;

            if (!gameController.dragController.GetCurrentTile())
            {
                gameController.dragController.ResetCurrentDrag();
                gameController.dragController.ResetCurrentTile();
            }
            ResetDrag();
        }

    }

    public void OnMouseDrag()
    {
        if(interactable)
        {
            gameController.dragController.SetCurrentDrag(this);
            GetComponent<Image>().raycastTarget = false;
            dragging = true;
        }

    }
    public void Update()
    {
        if (dragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public void ResetDrag()
    {
        GetComponent<Image>().raycastTarget = true;

    }
}