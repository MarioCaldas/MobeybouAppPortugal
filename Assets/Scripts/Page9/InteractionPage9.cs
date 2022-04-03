using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPage9 : MonoBehaviour
{
    // Start is called before the first frame update
    public UI ui;
    public Sprite[] panosdeterra;
    public GameObject puff;
    public Audio audio;
    public AudioClip aC;
    void Start()
    {
        audio = FindObjectOfType<Audio>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        FindObjectOfType<UI>().glow.SetBool("glow", true);
        StartCoroutine(Tecer());
        StartCoroutine(sound());
    }

    private IEnumerator Tecer(){
        for (int i = 0; i <3; i++){
            yield return new WaitForSeconds(0.5f);
            puff.SetActive(true);
            puff.GetComponent<ParticleSystem>().Play();
            GetComponent<SpriteRenderer>().sprite = panosdeterra[i];
        }
        StartCoroutine(ui.Glow(0.4f));
    }

    IEnumerator sound()
    {
        yield return new WaitForSeconds(0.5f);
        audio.GetComponent<AudioSource>().PlayOneShot(aC);
    }
}
