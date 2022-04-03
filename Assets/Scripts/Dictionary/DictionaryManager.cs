using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DictionaryManager : MonoBehaviour
{
    public GameObject[] pages;
    public Button[] buttons;

    public GameObject nextBtn;
    public GameObject prevBtn;

    int tab;

    private void Start()
    {
        //CV tab
        //tab = 6;
        print("Tab Value: "+tab);
        prevBtn.SetActive(false);

        ColorBlock c = buttons[0].colors;
        c.normalColor = Color.white;
        buttons[0].colors = c;
    }

    public void OpenTab(int tabNumber)
    {
        for (int i = 0; i < 9; i++)
        {
            ColorBlock cb = buttons[i].colors;

            if (i == tabNumber)
            {
                pages[i].SetActive(true);
                cb.normalColor = Color.white;
            }
            else
            {
                pages[i].SetActive(false);
                cb.normalColor = cb.disabledColor;            
            }

            buttons[i].colors = cb;
        }

      /* if (tab == 6 && tabNumber != 6)
            prevBtn.SetActive(true);

        else if (tabNumber == 5)
            nextBtn.SetActive(false);

        else if (tab == 5 && tabNumber != 5)
            nextBtn.SetActive(true);

        tab = tabNumber;

        if (tab == 6)
            prevBtn.SetActive(false);*/

        if (tabNumber == 8){
            nextBtn.SetActive(false);
        }else if( tabNumber == 0){
            prevBtn.SetActive(false);
        }else{
            nextBtn.SetActive(true);
            prevBtn.SetActive(true);
        }
        tab = tabNumber;
    }

    public void Close()
    {
        SceneManager.LoadScene("Homepage");
    }

    public void Next()
    {
        Debug.Log(tab);
        if (tab == 12)
            OpenTab(0);
        else
            OpenTab(tab + 1);
    }

    public void Previous()
    {
        if (tab == 0)
            OpenTab(12);
        else
            OpenTab(tab - 1);
    }
}
