using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInstrumental : MonoBehaviour
{
    public Animator animalCV;
    public Animator tartaruginhas;
    // Start is called before the first frame update
    private bool isPlaying;
    public AudioSource audio;
    public AudioClip aCGuitar, aCTart, aCTartaruginhas;

    public void Start(){
        isPlaying = false;
    }


   public void OnMouseDown(){
        print("Character clicked ");
        if(!isPlaying){
            Debug.Log(audio.GetComponent<AudioSource>());
            audio.Play();
            audio.PlayOneShot(aCTart);
            audio.PlayOneShot(aCTartaruginhas);
            PlayInstrumental(true);
       }else{
            audio.Stop();
            PlayInstrumental(false);
       }
        FindObjectOfType<UI>().glow.SetBool("glow", true);
    }

   public void PlayInstrumental(bool state){

        isPlaying = state;
        GetComponent<Animator>().SetBool("isPlayingInstrument", state);
        animalCV.SetBool("TurtleDance", state);
        tartaruginhas.SetBool("TurtleDance", state);
   }
}
