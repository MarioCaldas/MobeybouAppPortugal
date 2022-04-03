using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antagonist : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private Animator myAnimator;
    public bool start;//check if player has started the game
    private bool doOnce;
    public AudioSource aS;
    public AudioClip moo;

    // Start is called before the first frame update
    void Start()
    {
        
        myAnimator = GetComponent<Animator>();
        myAnimator.SetBool("isIdle", true);
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (start)
        {
            GetComponent<AudioSource>().enabled = true;
            if (!doOnce)
            {   
                
                //aS.Play();
                doOnce = true;
                //StartCoroutine(PatternAntagonist());
            }
            myAnimator.SetBool("isRun", true);
            
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        }
    }


    public void Jump(float force)
    {
            aS.PlayOneShot(moo);
            rb.velocity = Vector2.up * force;
    }


    public IEnumerator PatternAntagonist()
    {
        yield return new WaitForSeconds(0.1f);
        //Jump();
        yield return new WaitForSeconds(5f);
        //Jump();
        yield return new WaitForSeconds(3.5f);
        //Jump();
    }

   
}
