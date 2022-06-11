using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk9 : MonoBehaviour
{
    public bool walk;
    public float speed;

    [SerializeField] private Transform initPos;

    [SerializeField] private Transform finalPos;

    [SerializeField] private bool jump;

    [SerializeField] private bool jump2;

    [SerializeField] private InteractionPage9Pt interactionPage;
    void Start()
    {
        walk = true;

        StartCoroutine(WalkSequence());
    }
    [SerializeField] float time = 0;

    private IEnumerator WalkSequence()
    {
        transform.position = initPos.position;

        float elapsedTime = 0;



        //transform.eulerAngles = new Vector3(0, -180, 0);
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(initPos.position, finalPos.position, (elapsedTime / time));
            elapsedTime += Time.deltaTime;


            if (jump)
                transform.position = new Vector3(transform.position.x, Mathf.PingPong((elapsedTime * 3), 1), transform.position.z);

            yield return null;
        }

        interactionPage.runDone = true;
    }
    public void Run()
    {
        GetComponent<Animator>().SetTrigger("Run");
    }
    public void Jump()
    {
        GetComponent<Animator>().SetBool("Jump", true);
    }
    public void ResetJump()
    {
        GetComponent<Animator>().SetBool("Jump", false);
    }
}
