using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage3Pt : MonoBehaviour
{
    [SerializeField] private Clickable clickable;

    private GameManager gm;

    [SerializeField] public GameObject boyGO;
    [SerializeField] public GameObject girlGO;

    private UI ui;

    private int totalFruits = 7;

    public int currentFruits;

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



        /*while (!clickable.clicked)
        {
            yield return null;
        }*/


        while (!FullBasket())
        {
            print(currentFruits);
            yield return null;
        }



        StartCoroutine(ui.Glow(1f));

    }

    public bool FullBasket()
    {
        if(currentFruits >= totalFruits)
        {
            return true;
        }
        return false;
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
