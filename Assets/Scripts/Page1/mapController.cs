using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapController : MonoBehaviour
{
    public AudioClip aCClick, aCMapOpen;
    private AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        FindObjectOfType<UI>().glow.SetBool("glow", true);
        aS.PlayOneShot(aCClick);
        aS.PlayOneShot(aCMapOpen);
        GetComponent<Animator>().SetBool("openMap", true);
    }
}
