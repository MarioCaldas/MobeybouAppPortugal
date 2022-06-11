using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    GameManager gameManager;
    public Sprite[] narrativeImages;
    public Sprite[] characterImages;
    public Sprite[] characterImagesOff;

    public Button[] languageBtns;
    public Button[] characterBtns;

    public GameObject narrativeButton;

    public GameObject noNarrationBtns;
    public GameObject loader1, loader2;

    private AudioSource aS;
    public AudioClip aC;//btns press sound

    // Analytics
    public bool GetCharacter
    {
        get
        {
            return gameManager.gender;
        }
    }

    private void Start()
    {
        aS = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();

        int narrationValue = gameManager.narrations ? 1 : 0;
        narrativeButton.GetComponent<Image>().sprite = narrativeImages[narrationValue];

        for (int i = 0; i < 2; i++)
        {
            if (i != gameManager.language)
            {
                DisableColor(i);
            }
        }
    }

    public void Close()
    {
        if (FindObjectOfType<GameManager>().music)
            aS.PlayOneShot(aC);

        StartCoroutine(LoadAsyncOperation(0));
    }

    public void Play()
    {
        if (FindObjectOfType<GameManager>().music)
            aS.PlayOneShot(aC);

        StartCoroutine(LoadAsyncOperation(2));
    }

    public void SwitchNarrative(GameObject narrativeButton)
    {
        if (FindObjectOfType<GameManager>().music)
            aS.PlayOneShot(aC);
        //switch narrative state
        int narrationValue = gameManager.narrations ? 0 : 1;
        gameManager.narrations = !gameManager.narrations;

        //switch button image
        narrativeButton.GetComponent<Image>().sprite = narrativeImages[narrationValue];

    }

    public void SwitchLanguage(int language)
    {
        if (FindObjectOfType<GameManager>().music)
            aS.PlayOneShot(aC);
        //switch button image
        if (language != gameManager.language)
        {
            DisableColor(gameManager.language);
        }

        //switch language state
        gameManager.language = language;
        EnableColor(gameManager.language);
    }

    private void DisableColor(int i)
    {

        ColorBlock cb = languageBtns[i].colors;
        cb.normalColor = new Color(255, 255, 255, 0.5f);

        languageBtns[i].colors = cb;
    }

    private void EnableColor(int i)
    {

        ColorBlock cb = languageBtns[i].colors;
        cb.normalColor = Color.white;

        languageBtns[i].colors = cb;
    }

    public void SwitchCharacter(bool gender)
    {
        if (FindObjectOfType<GameManager>().music)
            aS.PlayOneShot(aC);
        //switch gender state
        gameManager.gender = gender;

        int character = gameManager.gender ? 0 : 1;

        //switch button image
        for (int i = 0; i < 2; i++)
        {
            if (i == character)
            {
                //switch button image - selected
                characterBtns[character].GetComponent<Image>().sprite = characterImages[character];
            }
            else
            {
                //switch button image - unselected
                characterBtns[i].GetComponent<Image>().sprite = characterImagesOff[i];
            }
        }
    }

    private void Update()
    {
        if (!gameManager.narrations)
        {
            gameManager.customNarration = false;
            noNarrationBtns.SetActive(false);
        }
        else
        {
            noNarrationBtns.SetActive(true);
        }
    }

    IEnumerator LoadAsyncOperation(int name)
    {
        loader1.SetActive(true);
        loader2.SetActive(true);
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(name);
        yield return new WaitForEndOfFrame();
    }

}
