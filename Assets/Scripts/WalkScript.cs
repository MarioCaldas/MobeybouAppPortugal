using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour
{
    public Animator characterAnimator;
    public float Waittime;
    public float speed;
    [SerializeField]
    private UI ui;

    public Vector2 finalPosition;
    public bool walk;
    public bool isPage6;
    // Start is called before the first frame update
    void Awake()
    {   
        
        walk = false;
        characterAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Walk
        if(walk){
            characterAnimator.SetBool("isIdle", false);
            characterAnimator.SetBool("isWalk", true);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(finalPosition.x, finalPosition.y, 0), speed * Time.deltaTime);        
        //Idle
            if(transform.position.x == finalPosition.x)
            {
                if (isPage6)
                {
                    characterAnimator.SetTrigger("Page6");
                    walk = false;
                    characterAnimator.SetBool("isWalk", false);
                    StartCoroutine(ui.Glow(0.4f));
                }
                else
                {
                    print("Got to the destination");
                    walk = false;
                    characterAnimator.SetBool("isWalk", false);
                    characterAnimator.SetBool("isIdle", true);
                    StartCoroutine(ui.Glow(0.4f));
                }
            }
        }
    }


    public void ResetFromSurprised(){

        characterAnimator.SetBool("surprised", false);
        characterAnimator.SetBool("isIdle", true);
    }


    public void FlipCharacterAndGo(){

       StartCoroutine(WaitToFlip());
        
    }


    private IEnumerator WaitToFlip(){
        yield return new WaitForSecondsRealtime(Waittime);
        this.transform.localScale = new Vector3(1.2f, 1.2f, 1);
        walk = true;
    }

    public void OnMouseDown(){
        walk = true;
        
    
    }
    
}
