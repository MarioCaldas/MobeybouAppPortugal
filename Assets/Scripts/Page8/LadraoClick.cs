using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadraoClick : MonoBehaviour
{
    public InteractionPage8 ip8;
    private AudioSource aS;
    public AudioClip aCGirl, aCBoy, antagonista;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (ip8.antagonistaAnimator.GetBool("deliverpano"))
        {

            ip8.antagonistaAnimator.SetBool("deliverpano", false);
            ip8.characterAnimator.SetBool("CapeVerdeObject", true);

            if (gm.gender)
                aS.PlayOneShot(aCGirl);
            else
                aS.PlayOneShot(aCBoy);

        }
    }
}
