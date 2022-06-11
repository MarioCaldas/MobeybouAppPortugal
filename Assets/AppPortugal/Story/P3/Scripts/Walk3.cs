using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk3 : MonoBehaviour
{
    public float speed;

    [SerializeField] private Transform initPos;
    [SerializeField] private Transform midPos;
    [SerializeField] private Transform finalPos;

    public Animator characterAnimator;

    public InteractionPage3Pt interactionPageScript;

    public Dragble currentDragScript;

    private void Start()
    {
        characterAnimator = GetComponentInChildren<Animator>();

        StartCoroutine(WalkSequence(4));
    }


    private IEnumerator WalkSequence(float time)
    {
        transform.position = initPos.position;

        characterAnimator.SetBool("isIdle", false);
        //characterAnimator.SetBool("isWalk", true);
        characterAnimator.SetTrigger("isWalk");
        float elapsedTime = 0;


        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(initPos.position, midPos.position, (elapsedTime / time));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        characterAnimator.ResetTrigger("isWalk");
        characterAnimator.SetBool("isIdle", true);

        while (!interactionPageScript.FullBasket())
        {
            yield return null;
        }

        print("basket full");
       
        currentDragScript.basketFruits.SetActive(false);

        interactionPageScript.girlGO.transform.localScale = new Vector3(1, 1, 1);
        interactionPageScript.boyGO.transform.localScale = new Vector3(1, 1, 1);

        characterAnimator.SetBool("isIdle", false);

        characterAnimator.SetTrigger("WalkWithBasket");

        elapsedTime = 0;
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(midPos.position, finalPos.position, (elapsedTime / time));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}
