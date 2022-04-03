using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RecordButtonsUI : MonoBehaviour, IPointerClickHandler
{
    public int r;
    public StartMenuUI sMUI;

    private void Start()
    {
        sMUI = FindObjectOfType<StartMenuUI>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        for (int i = 0; i < sMUI.records.Length; i++)
        {
            if (i != r)
            {
                sMUI.records[i].GetComponent<Image>().sprite = sMUI.off;
                if (sMUI.records[i].transform.childCount > 2) //input field is on
                {
                    sMUI.records[i].transform.GetChild(1).GetComponent<Text>().color = new Color(245f / 255f, 95f / 255f, 88f / 255f); // Redish
                    sMUI.records[i].transform.GetChild(2).GetComponent<Text>().color = new Color(245f / 255f, 95f / 255f, 88f / 255f); // Redish
                }
                else //input field is off
                {
                    sMUI.records[i].transform.GetChild(0).GetComponent<Text>().color = new Color(245f / 255f, 95f / 255f, 88f / 255f); // Redish
                    sMUI.records[i].transform.GetChild(1).GetComponent<Text>().color = new Color(245f / 255f, 95f / 255f, 88f / 255f); // Redish
                }
            }
            sMUI.narratorBtn.transform.GetChild(0).GetComponent<Text>().color = new Color(245f / 255f, 95f / 255f, 88f / 255f); // Redish
            sMUI.narratorBtn.GetComponent<Image>().sprite = sMUI.off;

            sMUI.records[r].GetComponent<Image>().sprite = sMUI.on;

            Debug.Log(sMUI.records[i]);
            Debug.Log(sMUI.records[i].transform.childCount);

            if (sMUI.records[r].transform.childCount > 2) //input field is on
            {
                sMUI.records[r].transform.GetChild(1).GetComponent<Text>().color = new Color(243f / 255f, 216f / 255f, 143f / 255f, 1); // Whiteish
                sMUI.records[r].transform.GetChild(2).GetComponent<Text>().color = new Color(243f / 255f, 216f / 255f, 143f / 255f, 1); // Whiteish
            }
            else //input field is off
            {
                sMUI.records[r].transform.GetChild(0).GetComponent<Text>().color = new Color(243f / 255f, 216f / 255f, 143f / 255f, 1); // Whiteish
                sMUI.records[r].transform.GetChild(1).GetComponent<Text>().color = new Color(243f / 255f, 216f / 255f, 143f / 255f, 1); // Whiteish
            }


        }

        sMUI.gm.saveFile = r+1;
        sMUI.gm.customNarration = true;
    }
}
