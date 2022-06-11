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

        yield return new WaitForSeconds(2);

        animator.SetTrigger("Dance");

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
