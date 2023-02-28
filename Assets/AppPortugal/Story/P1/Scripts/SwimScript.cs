using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimScript : MonoBehaviour
{
    public Animator characterAnimator;
    public float Waittime;
    public float speed;
    [SerializeField] private UI ui;

    public bool swim;

    [SerializeField] private Transform initPos;
    [SerializeField] private Transform finalPos;

    bool towards = true;

    float initScaleX;

    float initPingValue;

    int upOrDown;

    void Start()
    {
        initScaleX = transform.localScale.x;

        transform.position = initPos.position;

        //transform.eulerAngles = new Vector3(0, 0, 0);
        initPingValue = 0;
    }

    void Update()
    {
        if(swim)
        {
            float pingPong = Mathf.PingPong(Time.time * speed, 1);

            if(pingPong > initPingValue)
            {
                upOrDown = 1;
                initPingValue = pingPong;
            }
            else if(pingPong < initPingValue)
            {
                upOrDown = 0;
                initPingValue = pingPong;
            }

            float distanceToEnd = Vector3.Distance(transform.position, finalPos.position);
            float distanceToInit = Vector3.Distance(transform.position, initPos.position);
            if (upOrDown == 0)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            else 
            {
                transform.eulerAngles = new Vector3(0, 0, 0);

            }
            transform.position = Vector3.Lerp(initPos.position, finalPos.position, pingPong);
           // print("pingPong " + pingPong);
        }


    }
}
