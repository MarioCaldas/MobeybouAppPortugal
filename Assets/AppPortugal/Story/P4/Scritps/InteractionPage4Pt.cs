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
    [SerializeField] private GameObject boyGO2;
    [SerializeField] private GameObject girlGO;
    [SerializeField] private GameObject girlGO2;

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
        characterAnimator2.SetTrigger("SitIdle");

    }

    private void SetCharacter()
    {
        if (gm.gender)
        {
            boyGO.SetActive(false);
            girlGO.SetActive(true);
            boyGO2.SetActive(false);
            girlGO2.SetActive(true);

            characterAnimator = girlGO.GetComponentInChildren<Animator>();
            characterAnimator2 = girlGO2.GetComponentInChildren<Animator>();

        }
        else
        {
            boyGO.SetActive(true);
            girlGO.SetActive(false);
            boyGO2.SetActive(true);
            girlGO2.SetActive(false);

            characterAnimator = boyGO.GetComponentInChildren<Animator>();
            characterAnimator2 = boyGO2.GetComponentInChildren<Animator>();

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
        characterAnimator2.SetTrigger("SitLaught");

        yield return new WaitForSeconds(2);

        tacho.clicked = false;


        while (!tacho.clicked)
        {
            yield return null;

        }
        sceneAnimator.SetTrigger("Half");
        characterAnimator.SetTrigger("SitLaught");
        characterAnimator2.SetTrigger("SitLaught");

        yield return new WaitForSeconds(2);

        tacho.clicked = false;

        while (!tacho.clicked)
        {
            yield return null;

        }
        sceneAnimator.SetTrigger("Empty");
        characterAnimator.SetTrigger("SitLaught");
        characterAnimator2.SetTrigger("SitLaught");

        yield return new WaitForSeconds(2);

        //tacho.clicked = false;

        print("start glow " + ui);

        StartCoroutine(ui.Glow(1f));

    }
}
