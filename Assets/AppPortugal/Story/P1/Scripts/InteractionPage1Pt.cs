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

    private GameManager gm;


    [SerializeField] private GameObject boyGO;
    [SerializeField] private GameObject girlGO;

    private UI ui;

    public Animator characterAnimator;

    private void Awake()
    {

        ui = FindObjectOfType<UI>();

        panoAnimator.gameObject.SetActive(false);
        mapAnimator.gameObject.SetActive(false);
        
        characterAnimator = GetComponentInChildren<Animator>();

    }

    private void Start()
    {
        print("start");
        gm = FindObjectOfType<GameManager>();

        print(gm);
        SetCharacter();

        StartCoroutine(Sequence());

        characterAnimator.SetTrigger("Swim");

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
        print("started");

        bottleAnimator.SetTrigger("bottleGlow");

        while(!bottle.clicked)
        {
            yield return null;
        }

        panoAnimator.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        panoAnimator.SetTrigger("Glow");


        while (!pano.clicked)
        {
            yield return null;
        }
        mapAnimator.gameObject.SetActive(true);


        StartCoroutine(ui.Glow(1f));

    }
}
