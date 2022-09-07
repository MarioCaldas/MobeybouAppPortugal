using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage11Pt : MonoBehaviour
{

    [SerializeField] public GameObject boyGO;
    [SerializeField] public GameObject girlGO;

    private GameManager gm;
    private UI ui;

    [SerializeField] private Animator pageAnimator;

    [SerializeField] private Animator theEndAnimator;


    private void Awake()
    {

        ui = FindObjectOfType<UI>();

    }
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();

        SetCharacter();

        StartCoroutine(Sequence());
    }

    private IEnumerator Sequence()
    {

        yield return new WaitForSeconds(4);
 

        StartCoroutine(ui.Glow(1f));

    }

    private void SetCharacter()
    {
        if (gm.gender)
        {
            boyGO.SetActive(false);
            girlGO.SetActive(true);

            pageAnimator.SetTrigger("girl");
        }
        else
        {
            boyGO.SetActive(true);
            girlGO.SetActive(false);
            pageAnimator.SetTrigger("boy");

        }
    }
}
