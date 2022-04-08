using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage1Pt : MonoBehaviour
{

    [SerializeField] private Clickable bottle;

    [SerializeField] private Clickable pano;

    [SerializeField] private Animator bottleAnimator;
    [SerializeField] private Animator panoAnimator;
    [SerializeField] private Animator mapAnimator;

    private void Start()
    {
        panoAnimator.gameObject.SetActive(false);
        mapAnimator.gameObject.SetActive(false);

        StartCoroutine(Sequence());
    }

    private IEnumerator Sequence()
    {

        bottleAnimator.SetTrigger("bottleGlow");

        while(!bottle.clicked)
        {
            yield return null;
        }

        panoAnimator.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        panoAnimator.SetTrigger("Glow");


        while (!pano.clicked)
        {
            yield return null;
        }
        mapAnimator.gameObject.SetActive(true);

    }
}
