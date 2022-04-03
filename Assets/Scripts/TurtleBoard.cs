using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleBoard : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip aCWalk, aCSign;
    private Audio audioManager;
    public WalkScript characterScript;
    public GameObject glowing;
    void Start()
    {
        audioManager = FindObjectOfType<Audio>();
        StartCoroutine(waitAbit());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickOnBoard(){
        if (FindObjectOfType<InteractionPage2>().touched)
        {
            FindObjectOfType<UI>().glow.SetBool("glow",true);
            glowing.SetActive(false);
            audioManager.GetComponent<AudioSource>().PlayOneShot(aCSign);
            audioManager.GetComponent<AudioSource>().PlayOneShot(aCWalk);
            characterScript.walk = true;
        }
    }

    public IEnumerator waitAbit()
    {
        yield return new WaitForSeconds(0.2f);
        characterScript = FindObjectOfType<WalkScript>();
    }
}
