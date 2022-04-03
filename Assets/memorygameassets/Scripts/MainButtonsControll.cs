using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtonsControll : MonoBehaviour {
    public void triggerMenuBehavior(int i) {
        switch(i) {
            default:
            case(0):
                SceneManager.LoadScene ("HomePage");
                break;
            case(1):
                SceneManager.LoadScene ("Page 1");
                break;
            case(2):
                SceneManager.LoadScene ("Page 2");
                break;
            case(3):
                SceneManager.LoadScene ("Page 3");
                break;
            case(4):
                SceneManager.LoadScene ("Page 4");
                break;
            case(5):
                SceneManager.LoadScene ("Page 5");
                break;
            case(6):
                SceneManager.LoadScene ("Page 6");
                break;
            case(7):
                SceneManager.LoadScene ("Page 7");
                break;
            case(8):
                SceneManager.LoadScene ("Page 8");
                break;
            case(9):
                SceneManager.LoadScene ("Page 9");
                break;
            case(10):
                SceneManager.LoadScene ("Page 10");
                break;
            case(11):
                SceneManager.LoadScene ("page 11");
                break;
            case(12):
                SceneManager.LoadScene ("ChaptersMenu1");
                break;
            case(13):
                SceneManager.LoadScene ("ChaptersMenu2");
                break;
            case(14):
                SceneManager.LoadScene ("Credits");
                break;
            case(15):
                SceneManager.LoadScene ("Dictionary");
                break;
            case(16):
                SceneManager.LoadScene ("StartMenu");
                break;
            case(17):
                SceneManager.LoadScene ("MemoryGame");
                break;
        }
    }
}
