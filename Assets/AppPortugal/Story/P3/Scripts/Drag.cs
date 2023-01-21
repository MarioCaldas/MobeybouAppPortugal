using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    [SerializeField] private Image image;

    [SerializeField] private Image onPlaceImage;

    public Glower glow;

    private Vector3 initPos;

    public GameObject basket;

    public bool inPlace;

    public InteractionPage3Pt interactionPageScript;

    bool isDragging;

    private void Start()
    {
        onPlaceImage.gameObject.SetActive(false);

        initPos = image.transform.localPosition;

    }

    public void DragHandler(BaseEventData data)
    {
        print(initPos);

        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            pointerData.position,
            canvas.worldCamera,
            out position);

        image.transform.position = canvas.transform.TransformPoint(position);
        transform.position = canvas.transform.TransformPoint(position);

        isDragging = true;

        if (!interactionPageScript.isDragging)
        {
            interactionPageScript.DragablesDisabler(gameObject, false);

            interactionPageScript.isDragging = true;
        }

        float distance = Vector3.Distance(transform.position, basket.transform.position);
        if (distance < 1)
        {
            print("aqui 1");

            onPlaceImage.gameObject.SetActive(true);
            image.gameObject.SetActive(false);
            gameObject.SetActive(false);
            inPlace = true;

            glow.StopGlow();

            interactionPageScript.currentFruits++;

            interactionPageScript.PlayFruitSound();

            interactionPageScript.DragablesDisabler(gameObject, true);
        }


        //interactionPageScript.DragablesDisabler(gameObject, true);

        interactionPageScript.isDragging = false;

    }

    public void Drop(BaseEventData data)
    {
        if(!inPlace)
        {
            image.transform.localPosition = initPos;
            transform.localPosition = initPos;

            interactionPageScript.DragablesDisabler(gameObject, true);

            print(initPos);

        }
    }

    /*
    private void Update()
    {
        if(!inPlace && !isDragging)
        {

            image.transform.position = initPos;
            transform.position = initPos;
        }
    }*/

}
