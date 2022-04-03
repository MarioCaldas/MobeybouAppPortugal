using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text textBox;
    [TextArea]
    public string englishFemale, englishMale;
    [TextArea]
    public string portugueseFemale, portugueseMale;

    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();

        if (gm.language == 0 && gm.gender)// female english
            textBox.text = englishFemale;
        else if (gm.language == 0 && !gm.gender) //male english
            textBox.text = englishMale;
        else if (gm.language == 1 && gm.gender) //portuguese female
            textBox.text = portugueseFemale;
        else //portuguese male
            textBox.text = portugueseMale;
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "StartMenu")
        {
            if (gm.language == 0 && gm.gender)// female english
                textBox.text = englishFemale;
            else if (gm.language == 0 && !gm.gender) //male english
                textBox.text = englishMale;
            else if (gm.language == 1 && gm.gender) //portuguese female
                textBox.text = portugueseFemale;
            else //portuguese male
                textBox.text = portugueseMale;
        }
    }
}
