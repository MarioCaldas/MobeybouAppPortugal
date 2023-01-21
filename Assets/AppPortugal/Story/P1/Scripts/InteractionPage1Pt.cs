using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage1Pt : MonoBehaviour
{

    [SerializeField] private Clickable bottle;

    [SerializeField] private Clickable pano;

    [SerializeField] private Animator bottleAnimator;
    [SerializeField] private Animator panoAnimatorUK;
    [SerializeField] private Animator panoAnimatorPt;

    [SerializeField] private Animator mapAnimator;

    private GameManager gm;


    [SerializeField] private GameObject boyGO;
    [SerializeField] private GameObject girlGO;

    private UI ui;

    public Animator characterAnimator;

    [Header("Audio")]
    [SerializeField] private AudioClip openMap1, openMap2;
    [SerializeField] private AudioSource aS;


    [SerializeField] private GameObject narrationText;

    private void Awake()
    {

        ui = FindObjectOfType<UI>();

        panoAnimatorUK.gameObject.SetActive(false);
        panoAnimatorPt.gameObject.SetActive(false);

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
        if (gm.gender)
        {
            girlGO.GetComponent<SwimScript>().swim = true;
        }
        else
        {
            boyGO.GetComponent<SwimScript>().swim = true;
        }

        bottleAnimator.SetTrigger("bottleGlow");

        while(!bottle.clicked)
        {
            yield return null;
        }
        if(gm.language == 0)
            panoAnimatorUK.gameObject.SetActive(true);
        else
            panoAnimatorPt.gameObject.SetActive(true);


        narrationText.SetActive(false);
        boyGO.SetActive(false);
        girlGO.SetActive(false);

        int rand = Random.Range(0, 1);
        if (rand == 0)
            aS.PlayOneShot(openMap1);
        else
            aS.PlayOneShot(openMap2);


        yield return new WaitForSeconds(1f);

        if (gm.language == 0)
        {
            panoAnimatorUK.SetTrigger("Glow");
            pano = panoAnimatorUK.transform.GetComponent<Clickable>();

        }
        else
        {
            panoAnimatorPt.SetTrigger("Glow");
            pano = panoAnimatorPt.transform.GetComponent<Clickable>();

        }

        while (!pano.clicked)
        {
            yield return null;
        }
        mapAnimator.gameObject.SetActive(true);


        StartCoroutine(ui.Glow(1f));

    }
}
