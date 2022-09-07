using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk8 : MonoBehaviour
{
    public Animator characterAnimator;

    [SerializeField] private Transform initPos;

    [SerializeField] private Transform finalPos;

    private void Start()
    {
        characterAnimator = GetComponentInChildren<Animator>();

    }

    public void StartMovement()
    {
        StartCoroutine(WalkSequence());

    }
    public void StartBoatMovement()
    {
        StartCoroutine(BoatSequence());

    }
    private IEnumerator WalkSequence()
    {
        transform.position = initPos.position;

        if(characterAnimator)
        {
            characterAnimator.SetBool("isIdle", true);
        }


        float elapsedTime = 0;

        float time = 6.4f;
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(initPos.position, finalPos.position, (elapsedTime / time));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

    }

    private IEnumerator BoatSequence()
    {
        transform.position = new Vector3(initPos.position.x, transform.position.y, transform.position.z);

        if (characterAnimator)
        {
            characterAnimator.SetBool("isIdle", true);
        }


        float elapsedTime = 0;

        float time = 6;
        while (elapsedTime < time)
        {
            float xMove = Mathf.Lerp(initPos.position.x, finalPos.position.x, (elapsedTime / time));
            transform.position = new Vector3(xMove, transform.position.y, transform.position.z);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

    }

}
