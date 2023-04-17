using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuUI : MonoBehaviour
{
    public GameManager gm;

    public Button narratorBtn;

    public Sprite on, off;//for the buttons
    public InputField[] records;
    public GameObject[] deletes;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        narratorBtn.GetComponent<Image>().sprite = on;
        narratorBtn.transform.GetChild(0).GetComponent<Text>().color = new Color(243f / 255f, 216f / 255f, 143f / 255f, 1);
        gm.customNarration = false;

        for (int i = 0; i < records.Length; i++)
        {
            if (gm.dh.text[i] != "")
            {
                records[i].text = gm.dh.text[i];
                records[i].enabled = false;
                deletes[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    public void ClickOnNarrator()
    {
        gm.saveFile = 0;

        for(int i =0; i<records.Length;i++)
        {
            records[i].GetComponent<Image>().sprite = off;
            if (records[i].transform.childCount > 2)
            {
                records[i].transform.GetChild(1).GetComponent<Text>().color = new Color(245f / 255f, 95f / 255f, 88f / 255f); // Redish
                records[i].transform.GetChild(2).GetComponent<Text>().color = new Color(245f / 255f, 95f / 255f, 88f / 255f); // Redish
            }
            else
            {
                records[i].transform.GetChild(0).GetComponent<Text>().color = new Color(245f / 255f, 95f / 255f, 88f / 255f); // Redish
                records[i].transform.GetChild(1).GetComponent<Text>().color = new Color(245f / 255f, 95f / 255f, 88f / 255f); // Redish
            }
        }

        narratorBtn.transform.GetChild(0).GetComponent<Text>().color = new Color(243f / 255f, 216f / 255f, 143f / 255f, 1); // Whiteish
        narratorBtn.GetComponent<Image>().sprite = on;
        gm.customNarration = false;
    }

    public void FinishEndText(int r)
    {
        records[r].enabled = false;
        gm.dh.text[r] = records[r].text;
        deletes[r].GetComponent<Button>().interactable = true;
        gm.Save();
    }

    public void ClickOnRecords(int r)
    {
        for (int i = 0; i < records.Length; i++)
        {
            if (i != r)
            {
                records[i].GetComponent<Image>().sprite = off;
                records[i].transform.GetChild(1).GetComponent<Text>().color = new Color(245f / 255f, 95f / 255f, 88f / 255f); // Redish
            }
            narratorBtn.transform.GetChild(0).GetComponent<Text>().color = new Color(245f / 255f, 95f / 255f, 88f / 255f); // Redish
            narratorBtn.GetComponent<Image>().sprite = off;

            records[r].GetComponent<Image>().sprite = on;
            records[r].transform.GetChild(1).GetComponent<Text>().color = new Color(243f / 255f, 216f / 255f, 143f / 255f, 1); // Whiteish
        }
    }

    public void DeleteSave(int saveFile)
    {
        /*for (int i = 1; i <= 12; i++)
        {
            string path = Application.persistentDataPath + "/" + saveFile + "Page"+i + ".wav";
            File.Delete(path);
        }*/
        string path = Application.persistentDataPath + "/" + saveFile + "Page";
        print(path);
        print(saveFile + "Page");
        File.Delete(path);

        deletes[saveFile-1].GetComponent<Button>().interactable = false;
        records[saveFile-1].text = "";
        records[saveFile-1].enabled = true;
        gm.dh.text[saveFile-1] = "";
        //UnityEditor.AssetDatabase.Refresh();
        gm.Save();
    }
}
