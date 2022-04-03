using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    public Vector2 initialPosition;
    public Vector2 finalPosition;
    public int myNumber;

    public bool isRight;
    private bool locked;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 0;
        if (isRight)
        {
            transform.position = finalPosition;
            locked = true;
        }
        else
            transform.position = initialPosition;
    }

    void OnMouseDown()
    {

        if (!locked)
        {
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }

    private void OnMouseDrag()
    {
        if (!locked)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 1;
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="receiver")
        {
            Debug.Log("Entrei" + collision.GetComponent<Receiver>().myNumber);

            if (collision.GetComponent<Receiver>().myNumber == myNumber)
                isRight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "receiver")
        {
                isRight = false;
        }
    }
}
