using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public bool walk;
    public float speed;

    [SerializeField] private Transform initPos;
    [SerializeField] private Transform initPos2;

    [SerializeField] private Transform finalPos;
    [SerializeField] private Transform finalPos2;

    public Animator characterAnimator;

    private Vector3 initScale;

    private void Start()
    {
        walk = true;
        characterAnimator = GetComponentInChildren<Animator>();

        initScale = transform.localScale;

        StartCoroutine(WalkSequence());
    }

    private IEnumerator WalkSequence()
    {
        transform.position = initPos.position;

        characterAnimator.SetBool("isIdle", false);
        //characterAnimator.SetBool("isWalk", true);
        characterAnimator.SetTrigger("isWalk");
        float elapsedTime = 0;

        transform.eulerAngles = new Vector3(0, -180, 0);
        float time = 2;
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(initPos.position, finalPos.position, (elapsedTime / time));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.eulerAngles = new Vector3(0, 0, 0);

        transform.localScale = initScale * 2;

        GetComponentInChildren<MeshRenderer>().sortingOrder = 1;

        elapsedTime = 0;
        time = 5.5f;
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(initPos2.position, finalPos2.position, (elapsedTime / time));
            elapsedTime += Time.deltaTime;

            print("aqweqwe");
            yield return null;
        }
    }
}
