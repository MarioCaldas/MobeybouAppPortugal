using PathCreation.Examples;
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

    [SerializeField] private PathFollower careto;

    private float currentElapsedTime;

    private float testeValue;

    void Start()
    {
        walk = true;

        testeValue = 1;

        StartCoroutine(WalkSequence(currentElapsedTime));
    }
    [SerializeField] float time = 0;

    private IEnumerator WalkSequence(float _currentElapsedTime)
    {
        transform.position = initPos.position;

        float elapsedTime = _currentElapsedTime;

        Run();

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime * testeValue;

            transform.position = Vector3.Lerp(initPos.position, finalPos.position, (elapsedTime / time));

            currentElapsedTime = elapsedTime;

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
        if(GetComponent<Animator>())
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

        GetComponent<Animator>().SetTrigger("Run");

    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().ResetTrigger("isIdle");
            //StartCoroutine(WalkSequence(currentElapsedTime));

            Jump();
            careto.speed = 2.9f;

            testeValue = 1;

            camController.speedValue = 1;

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
            //StopAllCoroutines();
            GetComponent<Animator>().SetTrigger("isIdle");
            testeValue = 0;
            //StartCoroutine(WalkSequence());
            //camController.ResetCamera();
            //careto.RestartRun();
            camController.speedValue = 0;
            careto.speed = 0;
        }
    }
}
