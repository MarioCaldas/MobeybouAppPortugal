using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage9Pt : MonoBehaviour
{

    [SerializeField] public GameObject boyGO;
    [SerializeField] public GameObject girlGO;

    private GameManager gm;
    private UI ui;

    [SerializeField] public bool runDone;

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


        while (!runDone)
        {
            yield return null;
        }


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
