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


    void Start()
    {
    }

    public void UpdatePlayer()
    {
        if(boyPlaying)
        {
            print("boyPlaying");
            boyAnimator.SetBool("isIdle", false);

            boyAnimator.SetTrigger("PlayGuitar");

            aBoyAnimator.SetBool("isIdle", true);
            girlAnimator.SetBool("isIdle", true);
        }
        else if(girlPlaying)
        {
            girlAnimator.SetBool("isIdle", false);

            print("girlPlaying");
            girlAnimator.SetTrigger("PlayGuitar");
            boyAnimator.ResetTrigger("PlayGuitar");
            boyAnimator.SetBool("isIdle", true);
            aBoyAnimator.SetBool("isIdle", true);

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

        }
    }
    
}
