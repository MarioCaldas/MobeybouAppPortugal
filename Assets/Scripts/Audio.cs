using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource aS;
    public AudioClip englishFemale, englishMale;
    public AudioClip portugueseFemale, portugueseMale;

    private GameManager gm;

    void Start()
    {
        aS = GetComponent<AudioSource>();
        gm = FindObjectOfType<GameManager>();


        if (!gm.customNarration)
        {
            if (gm.narrations)
            {
                if (gm.language == 0 && gm.gender)// female english
                    aS.PlayOneShot(englishFemale);
                else if (gm.language == 0 && !gm.gender) //male english
                    aS.PlayOneShot(englishMale);
                else if (gm.language == 1 && gm.gender) //portuguese female
                    aS.PlayOneShot(portugueseFemale);
                else //portuguese male
                    aS.PlayOneShot(portugueseMale);
            }
        }
    }

    //public void ToggleSound(){
    //    if(PlayerPrefs.GetInt("soundOn") == 1){
    //        aS.Stop();
    //        PlayerPrefs.SetInt("soundOn", 0);
    //    }else{
    //        aS.Play();
    //        PlayerPrefs.SetInt("soundOn", 1);
    //    }
    //}
}
