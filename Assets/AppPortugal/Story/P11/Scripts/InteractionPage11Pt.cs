using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage11Pt : MonoBehaviour
{

    [SerializeField] public GameObject boyGO;
    [SerializeField] public GameObject girlGO;

    private GameManager gm;
    private UI ui;

    private void Awake()
    {

        ui = FindObjectOfType<UI>();

    }
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();

        SetCharacter();

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
