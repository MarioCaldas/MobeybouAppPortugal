using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePageMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
            Destroy(gameObject);

        if (!FindObjectOfType<GameManager>().music)
        {
            GetComponent<AudioSource>().volume = 0;
        }
    }

    private void Update()
    {
        if (!FindObjectOfType<GameManager>().music)
        {
            GetComponent<AudioSource>().volume = 0;
        }

        if (SceneManager.GetActiveScene().name != "Dictionary" && SceneManager.GetActiveScene().name != "CreditsMenu" && SceneManager.GetActiveScene().name != "StartMenu" && SceneManager.GetActiveScene().name != "Homepage" && SceneManager.GetActiveScene().name != "MemoryGame" && SceneManager.GetActiveScene().name != "ChaptersMenu")
            {
                Destroy(this.gameObject);
            }       
    }
}
