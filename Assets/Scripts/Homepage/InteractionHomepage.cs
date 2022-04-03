using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHomepage : MonoBehaviour
{
    public Animator girlAnimator;
    public Animator boyAnimator;

    void Start()
    {
        girlAnimator.SetBool("isIdle", true);
        boyAnimator.SetBool("isIdle", true);
    }
}
