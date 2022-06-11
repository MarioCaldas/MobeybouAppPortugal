using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage5Pt : MonoBehaviour
{
    [SerializeField] private Clickable clickable;

    private GameManager gm;

    [SerializeField] public GameObject boyGO;
    [SerializeField] public GameObject girlGO;

    [SerializeField] public GameObject mask;

    private UI ui;
    private void Awake()
    {

        ui = FindObjectOfType<UI>();

    }
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();

        SetCharacter();

        StartCoroutine(Sequence());

    }
    private IEnumerator Sequence()
    {
        SetCharacter();

        while (!clickable.clicked)
        {
            yield return null;
        }

        mask.SetActive(true);

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
