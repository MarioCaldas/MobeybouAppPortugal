using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsPage : MonoBehaviour
{
    public GameObject en, pt;

    // Start is called before the first frame update
    void Start()
    {
        if(FindObjectOfType<GameManager>().language ==0)
        {
            en.SetActive(false);
            pt.SetActive(true);
        }
        else
        {
            en.SetActive(true);
            pt.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeCredits()
    {
        SceneManager.LoadScene("HomePage");
    }
}
