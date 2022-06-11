using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage8Pt : MonoBehaviour
{
    [SerializeField] private Clickable clickable;

    private GameManager gm;

    [SerializeField] public GameObject boyGO;
    [SerializeField] public GameObject girlGO;

    private UI ui;

    [SerializeField] private GameObject boat;

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

        if (gm.gender)
        {
            girlGO.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);

            girlGO.GetComponent<Walk8>().StartMovement();
        }
        else
        {
            boyGO.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            boyGO.GetComponent<Walk8>().StartMovement();

        }


        boat.GetComponent<Walk8>().StartMovement();

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
