using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragble : MonoBehaviour
{
    public bool dragging;

    public bool interactable;

    public GameObject currentDrag;

    public GameObject basket;
    public GameObject basketFruits;

    public DragableOption currentDragScript;

    public InteractionPage3Pt interactionPageScript;

    public void Update()
    {
        if (currentDrag)
        {
            currentDrag.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            float distance = Vector3.Distance(currentDrag.transform.position, basket.transform.position);

            if(distance < 80)
            {
                //Vector3 randomVector = new Vector3(Random.Range(basket.transform.position.x - 120f, basket.transform.position.x + 120f), Random.Range(basket.transform.position.y, basket.transform.position.y), basket.transform.position.z);

                currentDrag.transform.localPosition = currentDragScript.finalPos;
                currentDragScript.inPlace = true;
                currentDrag = null;

                interactionPageScript.currentFruits++;

            }

        }
    }
}
