using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMaster : MonoBehaviour
{
    public GameManager gm;
    public GameObject button1, button2;
    public Audio audio;

    public Sprite muteOn, muteOff;
    public Sprite narrationOn, narrationOff;

    public bool toggle;


    public void Start()
    {
        if(FindObjectOfType<Audio>() !=null)
        audio = FindObjectOfType<Audio>();

        gm = FindObjectOfType<GameManager>();
        button1 = transform.GetChild(1).gameObject;
        button2 = transform.GetChild(2).gameObject;


        Refresh();

    }

    public void ToggleButtons()
    {
        if (toggle)
        {
            button1.SetActive(false);
            button2.SetActive(false);
            toggle = false;
        }
        else if (!toggle)
        {
            button1.SetActive(true);
            button2.SetActive(true);
            toggle = true;
        }
    }

    public void Toggle()//music toggle
    {
        if (gm.music)
        {
            gm.music = false;

            AudioListener.volume = 0f;
        }
        else
        {
            gm.music = true;

            AudioListener.volume = 1f;

        }
        Refresh();
    }

    public void ToggleNarration()//narration toggle
    {
        if (gm.narrations)
            gm.narrations = false;
        else
            gm.narrations = true;

        Refresh();
    }

    public void Refresh()
    {
        if (audio != null)
        {
            if (gm.narrations)
            {
                button1.GetComponent<Image>().sprite = narrationOff;
                audio.GetComponent<AudioSource>().volume = 1;
            }
            else
            {
                button1.GetComponent<Image>().sprite = narrationOn;
                audio.GetComponent<AudioSource>().volume = 0;
            }
        }

        if(gm.music)
        {
            foreach (AudioSource aS in FindObjectsOfType<AudioSource>())
            {
                if (audio != null)
                {
                    if (aS != audio.GetComponent<AudioSource>())
                    {
                        aS.volume = 0.8f;
                    }
                }
                else
                {
                    aS.volume = 0.8f;
                }
            }
            button2.GetComponent<Image>().sprite = muteOff;
        }
        else
        {
            foreach (AudioSource aS in FindObjectsOfType<AudioSource>())
            {
                if (audio != null)
                {
                    if (aS != audio.GetComponent<AudioSource>())
                    {
                        aS.volume = 0f;
                    }
                }
                else
                {
                    aS.volume = 0f;
                }
            }
            button2.GetComponent<Image>().sprite = muteOn;
        }
    }
}
