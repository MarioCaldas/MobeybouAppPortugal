using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Animator glow;
    public Transform loader;

    public GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();

    }

    public void TheEnd()
    {
        SceneManager.LoadScene("TheEndScene");

    }

    public void Next()
    {
        print("NEXT");
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        gm.storyChapterNumber = currentBuildIndex - 2;
        StartCoroutine(LoadAsyncOperation(currentBuildIndex));
    }

    public void Previous()
    {
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex - 1;
        gm.storyChapterNumber = currentBuildIndex - 2;
        StartCoroutine(LoadAsyncOperation(currentBuildIndex));
    }


    public void Home(){
        SceneManager.LoadScene("HomePage1");
        StartCoroutine(LoadAsyncOperation(0));
    }

    public void Chapters()
    {
        SceneManager.LoadScene("ChaptersMenu 1");
    }

    public IEnumerator Glow(float time)
    {
        yield return new WaitForSeconds(time);
        glow.SetBool("glow", true);
    }

    public IEnumerator LoadAsyncOperation(int name)
    {
        loader.transform.GetChild(0).gameObject.SetActive(true);
        //loader.transform.GetChild(1).gameObject.SetActive(true);
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(name);
        Debug.Log(gameLevel.progress);
        yield return new WaitForEndOfFrame();
    }

    public IEnumerator LoadAsyncOperation()
    {
        //loader.transform.GetChild(0).gameObject.SetActive(true);
        //loader.transform.GetChild(1).gameObject.SetActive(true);
        /*AsyncOperation gameLevel = SceneManager.LoadSceneAsync(name);
        Debug.Log(gameLevel.progress);*/
        SceneManager.LoadScene("Page12");
        yield return new WaitForEndOfFrame();
    }

}
