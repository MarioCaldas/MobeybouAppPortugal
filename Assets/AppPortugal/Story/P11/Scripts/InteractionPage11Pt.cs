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

    [Header("Audio")]
    [SerializeField] public AudioClip girlLaught, boyLaught;
    [SerializeField] public AudioSource aS;
    private void Awake()
    {

        ui = FindObjectOfType<UI>();

    }
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gm.onStoryMode?.Invoke();

        SetCharacter();

        StartCoroutine(Sequence());
    }

    private IEnumerator Sequence()
    {

        yield return new WaitForSeconds(13);

        StartCoroutine(ui.Glow(1f));

        yield return new WaitForSeconds(7);

        ui.TheEnd();


    }

    private void SetCharacter()
    {
        if (gm.gender)
        {
            boyGO.SetActive(false);
            girlGO.SetActive(true);

            pageAnimator.SetTrigger("girl");

            aS.PlayOneShot(girlLaught);
        }
        else
        {
            boyGO.SetActive(true);
            girlGO.SetActive(false);
            pageAnimator.SetTrigger("boy");

            aS.PlayOneShot(boyLaught);

        }
    }
}
