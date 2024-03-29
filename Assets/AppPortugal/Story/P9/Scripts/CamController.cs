using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public bool walk;
    public float speed;

    [SerializeField] private Transform initPos;

    [SerializeField] private Transform finalPos;

    private Vector3 initScale;

    public float speedValue;

    void Start()
    {
        walk = true;
        speedValue = 1;


        StartCoroutine(WalkSequence());

    }

    private IEnumerator WalkSequence()
    {
        yield return new WaitForSeconds(4f);

        transform.position = initPos.position;

        float elapsedTime = 0;

        float time = 9.6f;
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(initPos.position, finalPos.position, (elapsedTime / time) * speed);
            elapsedTime += Time.deltaTime * speedValue;

            yield return null;
        }

    }

    public void ResetCamera()
    {
        StopAllCoroutines();
        StartCoroutine(WalkSequence());
    }
}
