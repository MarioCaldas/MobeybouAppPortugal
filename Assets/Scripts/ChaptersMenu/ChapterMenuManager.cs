using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterMenuManager : MonoBehaviour
{
    SceneManager sceneManager;
    public GameObject firstChapter;
    public GameObject secondChapter;

    public string previousScene;

    public void Next()
    {
        firstChapter.SetActive(false);
        secondChapter.SetActive(true);
    }

    public void Previous()
    {
        secondChapter.SetActive(false);
        firstChapter.SetActive(true);
    }

    public void Close()
    {
        SceneManager.LoadScene(previousScene);
    }

    public void Page1()
    {
        SceneManager.LoadScene("Page1");
    }

    public void Page2()
    {
        SceneManager.LoadScene("Page2");
    }

    public void Page3()
    {
        SceneManager.LoadScene("Page3");
    }

    public void Page4()
    {
        SceneManager.LoadScene("Page4");
    }

    public void Page5()
    {
        SceneManager.LoadScene("Page5");
    }

    public void Page6()
    {
        SceneManager.LoadScene("Page6");
    }

    public void Page7()
    {
        SceneManager.LoadScene("Page7");
    }

    public void Page8()
    {
        SceneManager.LoadScene("Page8");
    }

    public void Page9()
    {
        SceneManager.LoadScene("Page9");
    }

    public void Page10()
    {
        SceneManager.LoadScene("Page10");
    }

    public void Page11()
    {
        SceneManager.LoadScene("Page11");
    }

    public void Page12()
    {
        SceneManager.LoadScene("ARMenu");
    }

    public void MemoryGame(){
        SceneManager.LoadScene("MemoryGame");
    }
    public void TicTacToeGame()
    {
        SceneManager.LoadScene("TicTacToeGame");
    }
    public void StartMenu(){
        SceneManager.LoadScene("StartMenu");
    }

    public void ChaptersMenu(){
        SceneManager.LoadScene("ChaptersMenu");
    }

    public void Dictionary(){
        SceneManager.LoadScene("Dictionary");
    }

    public void Credits()
    {
        SceneManager.LoadScene("CreditsMenu");
    }
}
