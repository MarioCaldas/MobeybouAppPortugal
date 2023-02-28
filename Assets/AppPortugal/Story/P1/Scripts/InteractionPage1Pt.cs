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

    [SerializeField] private GameObject seaFilter;

    private GameManager gm;


    [SerializeField] private GameObject boyGO;
    [SerializeField] private GameObject girlGO;

    private UI ui;

    public Animator characterAnimator;

    [Header("Audio")]
    [SerializeField] private AudioClip openMap1, openMap2;
    [SerializeField] private AudioSource aS;
    public AudioClip englishFemale, englishMale;
    public AudioClip portugueseFemale, portugueseMale;

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
        gm = FindObjectOfType<GameManager>();

        SetCharacter();

        StartCoroutine(Sequence());

        characterAnimator.SetTrigger("Swim");

        gm.onStoryMode?.Invoke();

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
        bottleAnimator.enabled = false;

        if (gm.gender)
        {
            girlGO.GetComponent<SwimScript>().swim = true;
        }
        else
        {
            boyGO.GetComponent<SwimScript>().swim = true;
        }

        yield return new WaitForSeconds(7);

        bottleAnimator.enabled = true;

        bottleAnimator.SetTrigger("bottleGlow");


        while (!bottle.clicked)
        {
            yield return null;
        }
        if(gm.language == 0)
            panoAnimatorUK.gameObject.SetActive(true);
        else
            panoAnimatorPt.gameObject.SetActive(true);

        seaFilter.SetActive(false);

        if (gm.gender)//girl
        {
            if (gm.language == 0)//uk
                aS.PlayOneShot(englishFemale);
            else
                aS.PlayOneShot(portugueseFemale);
        }
        else
        {
            if (gm.language == 0)//uk
                aS.PlayOneShot(englishMale);
            else
                aS.PlayOneShot(portugueseMale);
        }

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
