using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage4Pt : MonoBehaviour
{
    [SerializeField] private Clickable tacho;

    public Animator characterAnimator;
    public Animator characterAnimator2;

    public Animator sceneAnimator;

    private GameManager gm;

    [SerializeField] private GameObject boyGO;
    [SerializeField] private GameObject girlGO;
    [SerializeField] private GameObject brazilianGirl;

    private UI ui;

    private void Awake()
    {
        ui = FindObjectOfType<UI>();
    }

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();

        StartCoroutine(Sequence());

        SetCharacter();

        characterAnimator.SetTrigger("SitIdle");

        characterAnimator2 = brazilianGirl.GetComponent<Animator>();

    }

    private void SetCharacter()
    {
        if (gm.gender)
        {
            boyGO.SetActive(false);
            girlGO.SetActive(true);

            characterAnimator = girlGO.GetComponentInChildren<Animator>();

        }
        else
        {
            boyGO.SetActive(true);
            girlGO.SetActive(false);

            characterAnimator = boyGO.GetComponentInChildren<Animator>();
        }
    }

    private IEnumerator Sequence()
    {
        SetCharacter();

        while(!tacho.clicked)
        {
            yield return null;

        }
        
        sceneAnimator.SetTrigger("Full");
        characterAnimator.SetTrigger("SitLaught");
        characterAnimator2.SetTrigger("Laught");

        yield return new WaitForSeconds(2);

        tacho.clicked = false;


        while (!tacho.clicked)
        {
            yield return null;

        }
        sceneAnimator.SetTrigger("Half");
        characterAnimator.SetTrigger("SitLaught");
        characterAnimator2.SetTrigger("Laught");

        yield return new WaitForSeconds(2);

        tacho.clicked = false;

        while (!tacho.clicked)
        {
            yield return null;

        }
        sceneAnimator.SetTrigger("Empty");
        characterAnimator.SetTrigger("SitLaught");
        characterAnimator2.SetTrigger("Laught");

        yield return new WaitForSeconds(2);

        //tacho.clicked = false;


        StartCoroutine(ui.Glow(1f));

    }
}
