using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarPlayController : MonoBehaviour
{
    [SerializeField] private Animator boyAnimator;
    [SerializeField] private Animator girlAnimator;
    [SerializeField] private Animator aBoyAnimator;

    public bool boyPlaying;
    public bool girlPlaying;
    public bool AngolaBoyPlaying;
    private UI ui;


    [Header("Audio")]
    [SerializeField] private AudioClip guitar;
    [SerializeField] private AudioSource aS;
    void Start()
    {
        ui = FindObjectOfType<UI>();

    }

    public void UpdatePlayer()
    {
        if(boyPlaying)
        {

            print("boyPlaying");
            boyAnimator.SetBool("isIdle", false);

            boyAnimator.SetTrigger("PlayGuitar");

            aBoyAnimator.SetBool("isIdle", false);
            girlAnimator.SetBool("isIdle", false);

            aBoyAnimator.SetBool("Dance", true);
            girlAnimator.SetBool("Dance", true);

            if (!aS.isPlaying)
            {
                aS.PlayOneShot(guitar);

                Invoke("StopAnim", guitar.length);
            }



        }
        else if(girlPlaying)
        {
            girlAnimator.SetBool("isIdle", false);

            print("girlPlaying");
            girlAnimator.SetTrigger("PlayGuitar");
            boyAnimator.ResetTrigger("PlayGuitar");
            boyAnimator.SetBool("isIdle", true);
            aBoyAnimator.SetBool("isIdle", true);

            if(!aS.isPlaying)
                aS.PlayOneShot(guitar);

        }
        else if (AngolaBoyPlaying)
        {
            print("AngolaBoyPlaying");
            aBoyAnimator.SetBool("isIdle", false);

            aBoyAnimator.SetTrigger("PlayGuitar");

            boyAnimator.ResetTrigger("PlayGuitar");
            girlAnimator.ResetTrigger("PlayGuitar");
            boyAnimator.SetBool("isIdle", true);
            girlAnimator.SetBool("isIdle", true);

            if (!aS.isPlaying)
                aS.PlayOneShot(guitar);

        }
    }

    private void StopAnim()
    {
        print("stop anim");
        boyAnimator.ResetTrigger("PlayGuitar");
        boyAnimator.SetBool("isIdle", true);

        aBoyAnimator.ResetTrigger("Dance");
        aBoyAnimator.SetBool("isIdle", true);
        girlAnimator.ResetTrigger("Dance");
        girlAnimator.SetBool("isIdle", true);

        StartCoroutine(ui.Glow(1f));

        boyAnimator.GetComponentInParent<GuitarPlayer>().SwitchMeshes(false);
    }

}
