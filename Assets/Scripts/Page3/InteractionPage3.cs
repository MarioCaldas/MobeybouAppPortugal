using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPage3 : MonoBehaviour
{
    public Animator characterAnimator;
    private GameManager gm;
    public GameObject character, boyCharacter;
    private UI ui;

    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        ui = FindObjectOfType<UI>();

        if (gm.gender)
        {
            character.gameObject.SetActive(true);
            characterAnimator = character.GetComponent<Animator>();
        }
        else
        {
            boyCharacter.gameObject.SetActive(true);
            characterAnimator = boyCharacter.GetComponent<Animator>();
        }
        
    }

    public void SetSurprised()
    {
        characterAnimator.SetTrigger("suprised");
    }
}