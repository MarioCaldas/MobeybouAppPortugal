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

    [SerializeField] private List<GameObject> basket;

    private void Start()
    {
        characterAnimator = GetComponentInChildren<Animator>();

        StartCoroutine(WalkSequence(4));

        foreach (var item in basket)
        {
            item.gameObject.SetActive(false);
        }
    }


    private IEnumerator WalkSequence(float time)
    {
        transform.position = initPos.position;

        characterAnimator.SetBool("isIdle", false);
        //characterAnimator.SetBool("isWalk", true);
        characterAnimator.SetTrigger("WalkWithBasketEmpty");
        float elapsedTime = 0;


        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(initPos.position, midPos.position, (elapsedTime / time));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        characterAnimator.ResetTrigger("WalkWithBasketEmpty");
        characterAnimator.SetBool("isIdle", true);
        yield return new WaitForSeconds(0.3f);
        foreach (var item in basket)
        {
            item.gameObject.SetActive(true);
        }


        while (!interactionPageScript.FullBasket())
        {
            yield return null;
        }

        print("basket full");
       
        currentDragScript.basketFruits.SetActive(false);

        interactionPageScript.girlGO.transform.localScale = new Vector3(-interactionPageScript.girlGO.transform.localScale.x, interactionPageScript.girlGO.transform.localScale.y, interactionPageScript.girlGO.transform.localScale.z);
        interactionPageScript.boyGO.transform.localScale = new Vector3(-interactionPageScript.boyGO.transform.localScale.x, interactionPageScript.boyGO.transform.localScale.y, interactionPageScript.boyGO.transform.localScale.z);

        characterAnimator.SetBool("isIdle", false);

        characterAnimator.SetTrigger("WalkWithBasket");

        time = 6;
        elapsedTime = 0;
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(midPos.position, finalPos.position, (elapsedTime / time));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}
