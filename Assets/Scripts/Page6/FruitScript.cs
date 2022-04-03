using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;
    private Audio audioManager;
    public AudioClip pickFruit, finishFruit;

    private void Start()
    {
        audioManager = FindObjectOfType<Audio>();
    }

    void OnMouseDown()
    {
        audioManager.GetComponent<AudioSource>().PlayOneShot(pickFruit);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Blender")
        {
            audioManager.GetComponent<AudioSource>().PlayOneShot(finishFruit);
            FindObjectOfType<Page6Interaction>().fruitOnBlender++;
            Destroy(this.gameObject);
        }
    }
}
