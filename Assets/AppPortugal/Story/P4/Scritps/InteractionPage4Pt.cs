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

    [SerializeField] private GameObject plate1, plate2, plate3;

    [SerializeField] private GameObject smoke;

    [Header("Audio")]
    [SerializeField] private AudioClip boyLaught1, boyLaught2, girlLaught1, girlLaught2, pan, food, girlOnRight;
    [SerializeField] private AudioSource aS;
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


        plate1.SetActive(false);
        plate2.SetActive(false);
        plate3.SetActive(false);

        smoke.SetActive(false);

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

        plate1.SetActive(true);
        plate2.SetActive(false);
        plate3.SetActive(false);

        smoke.SetActive(true);

        sceneAnimator.SetTrigger("Full");
        characterAnimator.SetTrigger("SitLaught");
        characterAnimator2.SetTrigger("Laught");

        aS.PlayOneShot(pan);

        LaughtSounds();

        yield return new WaitForSeconds(2);

        tacho.clicked = false;


        while (!tacho.clicked)
        {
            yield return null;

        }

        plate1.SetActive(false);
        plate2.SetActive(true);
        plate3.SetActive(false);

        sceneAnimator.SetTrigger("Half");
        characterAnimator.SetTrigger("SitLaught");
        characterAnimator2.SetTrigger("Laught");


        LaughtSounds();

        aS.PlayOneShot(food);


        yield return new WaitForSeconds(2);

        tacho.clicked = false;

        while (!tacho.clicked)
        {
            yield return null;

        }
        plate1.SetActive(false);
        plate2.SetActive(false);
        plate3.SetActive(true);
        sceneAnimator.SetTrigger("Empty");
        characterAnimator.SetTrigger("SitLaught");
        characterAnimator2.SetTrigger("Laught");

        aS.PlayOneShot(food);

        LaughtSounds();

        yield return new WaitForSeconds(2);

        //tacho.clicked = false;


        StartCoroutine(ui.Glow(1f));

    }

    public void LaughtSounds()
    {
        int rand = Random.Range(0, 1);

        if (gm.gender)//girl
        {
            if (rand == 0)
                aS.PlayOneShot(girlLaught1);
            else
                aS.PlayOneShot(girlLaught2);

            aS.PlayOneShot(girlOnRight);

        }
        else
        {
            if (rand == 0)
                aS.PlayOneShot(boyLaught1);
            else
                aS.PlayOneShot(boyLaught2);

            aS.PlayOneShot(girlOnRight);

        }
    }
}
