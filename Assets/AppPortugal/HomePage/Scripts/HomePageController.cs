using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePageController : MonoBehaviour
{
    private GameManager gm;
    private UI ui;

    [SerializeField] private GameObject titlePt;
    [SerializeField] private GameObject titleEn;


    void Start()
    {
        ui = FindObjectOfType<UI>();

        gm = FindObjectOfType<GameManager>();

        SetPageLanguage();

    }

    public void SetPageLanguage()
    {
        print(gm.language);
        if(gm.language == 0)
        {
            titlePt.SetActive(false);
            titleEn.SetActive(true);
        }
        else
        {
            titlePt.SetActive(true);
            titleEn.SetActive(false);
        }
    }
}
