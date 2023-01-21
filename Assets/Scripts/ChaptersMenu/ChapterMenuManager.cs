using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapterMenuManager : MonoBehaviour
{
    SceneManager sceneManager;
    public GameObject firstChapter;
    public GameObject secondChapter;

    public string previousScene;

    public GameObject[] pages;
    public SpriteRenderer circle;

    private int number;

    public GameManager gm;


    private void Start()
    {
        gm = FindObjectOfType<GameManager>();

        if (gm.storyChapterNumber >= 6) //secondPage active
        {
            if(firstChapter)
                firstChapter.SetActive(false);
            
            if(secondChapter)
                secondChapter.SetActive(true);
        }

        if(firstChapter && secondChapter)
        CheckCircle();
    }

    private void CheckCircle()
    {
        if ((gm.storyChapterNumber < 7 && firstChapter.activeSelf) //circle is on the first page and current page is the first -> display the circle
            || (gm.storyChapterNumber >= 6 && secondChapter.activeSelf)) //circle is on the second page and current page is the second -> display the circle
        {
            circle.transform.position = pages[gm.storyChapterNumber].transform.position;
            circle.gameObject.SetActive(true);
        }
        else //don't draw the circle
        {
            circle.gameObject.SetActive(false);
        }
    }

    public void Next()
    {
        firstChapter.SetActive(false);
        secondChapter.SetActive(true);

        if (firstChapter && secondChapter)
            CheckCircle();

    }
    //95 horizontal fov page 1
    public void Previous()
    {
        secondChapter.SetActive(false);
        firstChapter.SetActive(true);

        if (firstChapter && secondChapter)
            CheckCircle();

    }

    public void Close()
    {
        SceneManager.LoadScene("HomePage1");

        //SceneManager.LoadScene(previousScene);
    }

    public void Page1()
    {
        //SceneManager.LoadScene("Page1");
        gm.storyChapterNumber = 0;
        
        SceneManager.LoadScene("PagePt1");
    }

    public void Page2()
    {
        //SceneManager.LoadScene("Page2");
        gm.storyChapterNumber = 1;

        SceneManager.LoadScene("PagePt2");
    }

    public void Page3()
    {
        SceneManager.LoadScene("PagePt3");
        gm.storyChapterNumber = 2;

        //SceneManager.LoadScene("Page3");
    }

    public void Page4()
    {
        SceneManager.LoadScene("PagePt4");
        //SceneManager.LoadScene("Page4");
        //gm.storyChapterNumber = 3;

    }

    public void Page5()
    {
        SceneManager.LoadScene("PagePt5");

        gm.storyChapterNumber = 4;

        //SceneManager.LoadScene("Page5");
    }

    public void Page6()
    {
        SceneManager.LoadScene("PagePt6");

        gm.storyChapterNumber = 5;

        //SceneManager.LoadScene("Page6");
    }

    public void Page7()
    {
        SceneManager.LoadScene("PagePt7");

        gm.storyChapterNumber = 6;

        //SceneManager.LoadScene("Page4");
    }

    public void Page8()
    {
        SceneManager.LoadScene("PagePt8");

        gm.storyChapterNumber = 7;

        //SceneManager.LoadScene("Page8");
    }

    public void Page9()
    {
        //SceneManager.LoadScene("Page9");
        SceneManager.LoadScene("PagePt9");

        gm.storyChapterNumber = 8;

    }

    public void Page10()
    {
        //SceneManager.LoadScene("Page10");
        SceneManager.LoadScene("PagePt10");

        gm.storyChapterNumber = 9;

    }

    public void Page11()
    {
        //SceneManager.LoadScene("Page11");
        SceneManager.LoadScene("PagePt11");

        gm.storyChapterNumber = 10;

    }

    public void Page12()
    {
        SceneManager.LoadScene("ARMenu");

        gm.storyChapterNumber = 11;

    }

    public void MemoryGame(){
        SceneManager.LoadScene("MemoryGame");
    }
    public void TicTacToeGame()
    {
        SceneManager.LoadScene("TicTacToeGame");
    }
    public void StartMenu(){
        //SceneManager.LoadScene("StartMenu");
        SceneManager.LoadScene("StartMenu 1");
    }

    public void ChaptersMenu(){
        SceneManager.LoadScene("ChaptersMenu 1");
    }

    public void Dictionary(){
        SceneManager.LoadScene("Dictionary 1");
    }

    public void Credits()
    {
        SceneManager.LoadScene("CreditsMenu");
    }
}
