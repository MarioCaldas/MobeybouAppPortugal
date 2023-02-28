using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentAudioSource2 : MonoBehaviour
{
    private static PersistentAudioSource2 instance;
    private GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();


        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }


    }

    private void Start()
    {

        if (!gm.onStoryModeBool)
        {
            //Destroy(gameObject);
        }
    }
}
