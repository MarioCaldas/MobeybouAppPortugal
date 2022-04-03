using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoPage3 : MonoBehaviour
{
    private GameManager gm;
    public Sprite girl, boy;
    // Start is called before the first frame update
    void Start()
    {
        gm=FindObjectOfType<GameManager>();

        if (gm.gender)
            transform.GetComponent<Image>().sprite = girl;
        else
            transform.GetComponent<Image>().sprite = boy;
    }
}
