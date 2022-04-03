using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pot : MonoBehaviour
{
    AudioSource audio;
    public AudioClip aCClick;
    public ParticleSystem pS;
    private int count;
    public GameObject boychar, girlchar;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if(count==12)
        {
            if(FindObjectOfType<GameManager>().gender)
            {
                girlchar.GetComponent<WalkScript>().walk = true;
            }
            else
            {
                boychar.GetComponent<WalkScript>().walk = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Ingredientes"))
       {
            count++;
            GameObject gO = Instantiate(pS.gameObject, new Vector2(0,-0.5f),Quaternion.identity);
            audio.GetComponent<AudioSource>().PlayOneShot(aCClick);
           Destroy(collision.gameObject);
       }
    }
}
