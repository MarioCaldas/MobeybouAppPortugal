using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage2Pt : MonoBehaviour
{
    [SerializeField] private Clickable clickable;

    private GameManager gm;

    [SerializeField] private GameObject boyGO;
    [SerializeField] private GameObject girlGO;

    private UI ui;

    [SerializeField] private Animator doorAnimator;

    [Header("Audio")]
    [SerializeField] private AudioClip click, walk;
    [SerializeField] private AudioSource aS;

    private void Awake()
    {

        ui = FindObjectOfType<UI>();

    }

    private void Start()
    {
        print("start");
        gm = FindObjectOfType<GameManager>();

        gm.onStoryMode?.Invoke();

        StartCoroutine(Sequence());


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
    private IEnumerator Sequence()
    {
        print("started");

        yield return new WaitForSeconds(1);
        doorAnimator.SetTrigger("glow");
       
        while (!clickable.clicked)
        {
            yield return null;
        }
        doorAnimator.ResetTrigger("glow");

        doorAnimator.SetTrigger("Idle");

        aS.PlayOneShot(walk);

        aS.PlayOneShot(click);

        SetCharacter();

        yield return new WaitForSeconds(6f);

        StartCoroutine(ui.Glow(1f));

    }
}
