using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPage9 : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <13.35f)
        transform.position = new Vector3(player.transform.position.x+6.58f, 0, -10);
    }
}
