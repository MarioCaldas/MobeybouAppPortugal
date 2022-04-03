using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARMenuManager : MonoBehaviour
{

    public Transform UI;
    public void Print(string url)
    {
        Application.OpenURL(url);
    }

    public void Play()
    {
        StartCoroutine(UI.GetComponent<UI>().LoadAsyncOperation(14));
    }
}
