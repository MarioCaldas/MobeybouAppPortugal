using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTheEndPageController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();

        if (gm.language == 0)
            animator.SetTrigger("en");
        else
            animator.SetTrigger("pt");
    }

}
