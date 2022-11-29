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

    [SerializeField] private AnimationCurve jumpCurve;

    [SerializeField] private CamController camController;

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

        Run();

        //transform.eulerAngles = new Vector3(0, -180, 0);
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(initPos.position, finalPos.position, (elapsedTime / time));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        interactionPage.runDone = true;

        if(GetComponent<AudioSource>())
        {
            GetComponent<AudioSource>().loop = false;
        }
    }

    public void Run()
    {
        GetComponent<Animator>().SetTrigger("Run");
    }

    bool jumpSoundPlayed;

    public void Jump()
    {
        if(GetComponent<Animator>())
        {
            GetComponent<BoxCollider>().enabled = false;

            GetComponent<Animator>().SetBool("Jump", true);

            if (!jumpSoundPlayed)
            {
                interactionPage.aS.PlayOneShot(interactionPage.jump);

                jumpSoundPlayed = true;
            }
            
            jump = true;

            StartCoroutine(ResetJump());
        }

    }
    public IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(1);

        GetComponent<Animator>().SetBool("Jump", false);

        jumpSoundPlayed = false;

        yield return new WaitForSeconds(0.5f);

        GetComponent<BoxCollider>().enabled = true;

    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            print("jump");
            Jump();

            //transform.position = new Vector3(transform.position.x, transform.position.y + 8, transform.position.z);
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            print("obstacle");
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            StopAllCoroutines();
            StartCoroutine(WalkSequence());
            camController.ResetCamera();
        }
    }
}
