﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Animator glow;
    public Transform loader;

    public void Next()
    {
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(LoadAsyncOperation(currentBuildIndex));
    }

    public void Previous()
    {
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex - 1;
        StartCoroutine(LoadAsyncOperation(currentBuildIndex));
    }


    public void Home(){
        SceneManager.LoadScene("HomePage");
        StartCoroutine(LoadAsyncOperation(0));
    }

    public void Chapters()
    {
        SceneManager.LoadScene("ChaptersMenu");
    }

    public IEnumerator Glow(float time)
    {
        yield return new WaitForSeconds(time);
        glow.SetBool("glow", true);
    }

    public IEnumerator LoadAsyncOperation(int name)
    {
        loader.transform.GetChild(0).gameObject.SetActive(true);
        loader.transform.GetChild(1).gameObject.SetActive(true);
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(name);
        Debug.Log(gameLevel.progress);
        yield return new WaitForEndOfFrame();
    }
}
