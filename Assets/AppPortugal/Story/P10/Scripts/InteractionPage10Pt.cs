using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage10Pt : MonoBehaviour
{

    [SerializeField] private Clickable clickable;

    [SerializeField] public GameObject boyGO;
    [SerializeField] public GameObject girlGO;

    private GameManager gm;
    private UI ui;

    [SerializeField] private Animator animator;
    [SerializeField] private Animator galoAnimator;

    [Header("Audio")]
    [SerializeField] public AudioClip girlLaught, boyLaught, animal, figures;
    [SerializeField] public AudioSource aS;
    private void Awake()
    {

        ui = FindObjectOfType<UI>();

    }
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();

        StartCoroutine(Sequence());


    }
    private IEnumerator Sequence()
    {
        SetCharacter();



        while (!clickable.clicked)
        {
            yield return null;
        }

        animator.SetTrigger("Appear");
        yield return new WaitForSeconds(0.5f);
        aS.PlayOneShot(figures);

        galoAnimator.SetTrigger("Scare");
        aS.PlayOneShot(animal);

        if (gm.gender)
        {
            girlGO.GetComponentInChildren<Animator>().SetTrigger("Laught");

            aS.PlayOneShot(girlLaught);
        }
        else
        {
            boyGO.GetComponentInChildren<Animator>().SetTrigger("Laught");

            aS.PlayOneShot(boyLaught);

        }
        animator.SetTrigger("Dance");

        yield return new WaitForSeconds(1.5f);
        if (gm.gender)
        {
            girlGO.GetComponentInChildren<Animator>().SetTrigger("Dance");
        }
        else
        {
            boyGO.GetComponentInChildren<Animator>().SetTrigger("Dance");
        }
        galoAnimator.SetTrigger("Dance");


        StartCoroutine(ui.Glow(1f));

    }
    private void SetCharacter()
    {
        if (gm.gender)
        {
            boyGO.SetActive(false);
            girlGO.SetActive(true);
        }
        else
        {
            boyGO.SetActive(true);
            girlGO.SetActive(false);

        }
    }
}