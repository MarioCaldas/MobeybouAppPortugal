using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage8Pt : MonoBehaviour
{
    [SerializeField] private Clickable clickable;

    private GameManager gm;

    [SerializeField] public GameObject boyGO;
    [SerializeField] public GameObject girlGO;
    [SerializeField] public GameObject marceloGO;

    private UI ui;

    [SerializeField] private GameObject boat;

    [SerializeField] private GameObject boatToHide;

    [SerializeField] private GameObject nightImage1;
    [SerializeField] private GameObject nightImage2;

    [Header("Audio")]
    [SerializeField] public AudioClip boatSound, click;
    [SerializeField] public AudioSource aS;

    [SerializeField] public AudioSource aSAmbiente;
    [SerializeField] public AudioClip nightSound, daySound;

    private void Awake()
    {

        ui = FindObjectOfType<UI>();

    }
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();

        StartCoroutine(Sequence());

        aSAmbiente.PlayOneShot(daySound);
    }
    private IEnumerator Sequence()
    {
        SetCharacter();



        while (!clickable.clicked)
        {
            yield return null;
        }
        aS.PlayOneShot(click);

        boatToHide.SetActive(false);
        if (gm.gender)
        {
            girlGO.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);

            girlGO.GetComponent<Walk8>().StartMovement();

            marceloGO.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            marceloGO.GetComponent<Walk8>().StartMovement();

        }
        else
        {
            boyGO.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            boyGO.GetComponent<Walk8>().StartMovement();

            marceloGO.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            marceloGO.GetComponent<Walk8>().StartMovement();

        }

        aS.PlayOneShot(boatSound);

        boat.GetComponent<Walk8>().StartBoatMovement();

        yield return new WaitForSeconds(5);
        StartCoroutine(NightSequence());

        aSAmbiente.PlayOneShot(nightSound);

        StartCoroutine(ui.Glow(1f));

    }

    private IEnumerator NightSequence()
    {
        float elapsedTime = 0;
        float totalTime = 2;

        while(elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;

            nightImage1.GetComponent<SpriteRenderer>().color = new Color(nightImage1.GetComponent<SpriteRenderer>().color.r, nightImage1.GetComponent<SpriteRenderer>().color.g, nightImage1.GetComponent<SpriteRenderer>().color.b, Mathf.Lerp(0, 1, elapsedTime / totalTime));
            nightImage2.GetComponent<SpriteRenderer>().color = new Color(nightImage2.GetComponent<SpriteRenderer>().color.r, nightImage2.GetComponent<SpriteRenderer>().color.g, nightImage2.GetComponent<SpriteRenderer>().color.b, Mathf.Lerp(0, 1, elapsedTime / totalTime));

            yield return null;
        }
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
