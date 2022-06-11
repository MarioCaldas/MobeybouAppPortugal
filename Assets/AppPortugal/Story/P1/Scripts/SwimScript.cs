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

    void Start()
    {
        initScaleX = transform.localScale.x;

        transform.position = initPos.position;
    }

    void Update()
    {
       
        float pingPong = Mathf.PingPong(Time.time * speed, 1);
        float distanceToEnd = Vector3.Distance(transform.position, finalPos.position);
        float distanceToInit = Vector3.Distance(transform.position, initPos.position);
        if(Mathf.Abs(distanceToEnd) <= 0.1)
        {
            transform.eulerAngles = new Vector3(0, -180,0);
        }
        if(Mathf.Abs(distanceToInit) <= 0.1)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        transform.position =  Vector3.Lerp(initPos.position, finalPos.position, pingPong);
    }
}
