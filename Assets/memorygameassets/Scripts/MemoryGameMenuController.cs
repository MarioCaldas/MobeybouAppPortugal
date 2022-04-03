using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MemoryGameMenuController : MonoBehaviour {
    public void triggerMenuBehavior(int i) {
        switch(i) {
            default:
            case(0):
                Application.Quit ();
                break;
            case(1):
                SceneManager.LoadScene ("MemoryGame");
                break;
        }
    }
}
