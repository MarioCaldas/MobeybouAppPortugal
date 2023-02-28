using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTheEndPageController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private GameManager gm;

    [Header("Audio")]
    [SerializeField] private AudioClip elefante;
    [SerializeField] private AudioSource aS;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gm.onStoryMode?.Invoke();

        if (gm.language == 0)
            animator.SetTrigger("en");
        else
            animator.SetTrigger("pt");

        Invoke("ElefanteSound", 1.5f);
    }


    private void ElefanteSound()
    {
        aS.PlayOneShot(elefante);
    }
}
