using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk9 : MonoBehaviour
{
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

    bool isRunning;

    void Start()
    {
        testeValue = 1;

        //GetComponent<Animator>().SetTrigger("glow9");
        StartCoroutine(WalkSequence(currentElapsedTime));
    }
    [SerializeField] float time = 0;


    private IEnumerator WalkSequence(float _currentElapsedTime)
    {
        /*if(!isRunning)
        {
            GameObject.FindGameObjectWithTag("Careto").GetComponent<PathFollower>().canGo = true; 

            yield return new WaitForSeconds(1.2f);
            isRunning = true;
        }*/

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

            //StartCoroutine(JumpSequence());

            //GetComponent<Rigidbody>().AddForce(Vector3.up * 7, ForceMode.Impulse);

            if (!jumpSoundPlayed)
            {
                interactionPage.aS.PlayOneShot(interactionPage.jump);

                jumpSoundPlayed = true;
            }
            
            jump = true;

            StartCoroutine(ResetJump());

            if (!isRunning)
            {
                StartCoroutine(WalkSequence(currentElapsedTime));
            }
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

            Jump();
            careto.speed = 2.9f;

            testeValue = 1;
            GameObject.FindGameObjectWithTag("Careto").GetComponent<PathFollower>().canGo = true;

            camController.speedValue = 1;

        }

        if(transform.position.y <= -3f)
        {
            //transform.position = new Vector3(transform.position.x, -2.5f, transform.position.z);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameObject.FindGameObjectWithTag("Careto").GetComponent<PathFollower>().canGo = false;

            GetComponent<Animator>().SetTrigger("isIdle");
            testeValue = 0;
            //StartCoroutine(WalkSequence());
            //camController.ResetCamera();
            //careto.RestartRun();
            camController.speedValue = 0;
            careto.speed = 0;

            //isRunning = false;
        }
    }
}
