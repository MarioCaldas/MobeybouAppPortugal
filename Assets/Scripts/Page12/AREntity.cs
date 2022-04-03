﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using System;

public class AREntity : MonoBehaviour
{
    public Animator animator;
    public string[] state = { "isIdle", "isLaughing", "isDancing", "isThunder" };
    public int animationIndex = 0;
    public bool isAnimal = false;
    public bool isCharacter = false;

    public AudioSource aS;
    public AudioClip[] aC;
    private int rand = 0;
    public int touchCount = 0;

    private void Awake()
    {
        //this is a character entity (Kaué or Iara)
        if (this.name.Contains("Luanna") || this.name.Contains("Marcelo"))
        {
            //isCharacter = true;
        }
        //this is the animal
        else if (this.name.Contains("Animal"))
        {
            isAnimal = true;
            state[1] = "isAttacking";
        }
        //this is the antagonist
        else
        {
            state[1] = "isScared";
        }

        //start idle animation
        animator.SetBool(state[animationIndex], true);

        //laugh and dance animations are no longer on loop
        Animation animation = animator.GetComponent<Animation>();
    }

    private void Update()
    {
        //the player touches the screen
        if (Input.GetMouseButtonDown(0) ||  Input.GetTouch(touchCount).phase == TouchPhase.Began)
        {
            //play click sound
            aS.PlayOneShot(aC[0]);

            //on the even touches, the character displays a laughing animation, the animal attacks and the antagonist gets scared
            if (!isCharacter && touchCount % 3 == 1 || isCharacter && touchCount % 2 == 0)
            {
                //stop all other animations
                animator.SetBool(state[2], false);
                animator.SetBool(state[0], false);

                if (!isCharacter && !isAnimal)
                    animator.SetBool("isThunder", false);

                //start laughing/attack/scared animation
                animationIndex = 1;
                animator.SetBool(state[animationIndex], true);

                StartCoroutine(Wait(1.5f));

                //play laughing or animal attack or scared antagonist sound
                aS.PlayOneShot(aC[animationIndex]);

                //start antagonist idle animation
                if (!isAnimal && !isCharacter)
                    StartCoroutine(WaitAnim(0.5f));

                //start animal & antagonist idle animation
                else 
                    StartCoroutine(WaitAnim(1));

                Debug.Log("1º");
            }

            //when the touch is an odd number, the character displays a dancing animation
            else if ((!isCharacter && touchCount % 3 == 2)
                    || isCharacter && touchCount % 2 != 0)
            {
                //stop all other animations
                animator.SetBool(state[1], false);
                animator.SetBool(state[0], false);

                if(!isCharacter && !isAnimal)
                    animator.SetBool("isThunder", false);

                //start dancing animation
                animationIndex = 2;

                animator.SetBool(state[animationIndex], true);

                StartCoroutine(Wait(1.5f));

                if(!isCharacter)
                {
                    //play animal/antagonist sound
                    aS.PlayOneShot(aC[animationIndex]);
                }

                StartCoroutine(WaitAnim(1));
                Debug.Log("2º");
            }

            //start bull thunder animation
            else if (!isCharacter && touchCount % 3 == 0)
            {
                //stop all other animations
                animator.SetBool(state[0], false);
                animator.SetBool(state[2], false);

                animationIndex = 3;

                //play thunder animation
                animator.SetBool(state[animationIndex], true);

                //play thunder sound
                aS.PlayOneShot(aC[animationIndex]);


                //start idle anim
                StartCoroutine(WaitAnim(1));
            }

            Debug.Log("4º");
            touchCount++;
        }
    }

    private IEnumerator Wait(float t)
    {
        yield return new WaitForSeconds(t);
    }

    private IEnumerator WaitAnim(float t)
    {
        //last animation was thunder - the bull makes a scared sound
        if(animationIndex == 3)
            aS.PlayOneShot(aC[1]);

        yield return new WaitForSeconds(t);
        //cancel previous animation
        animator.SetBool(state[animationIndex], false);
        //start idle animation
        animationIndex = 0;
        animator.SetBool(state[animationIndex], true);
    }
}

