using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private Animator myAnimator;

    public bool isGrounded;
    public Transform groundCheck;// the transform which you check if is on ground or not
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public Vector2 finalPosition;

    private bool doOnce; //just so it doesn't jump when you start the game

    public bool start;//check if player has started the game

    public bool gender;

    public GameManager gm;
    public AudioSource aS;
    public AudioClip aCJump;

    private UI ui;

    private void Awake()
    {
        
        gm = FindObjectOfType<GameManager>();
        ui = FindObjectOfType<UI>();

        if (gm.gender != gender)
            transform.gameObject.SetActive(false);
        else
            FindObjectOfType<CameraPage9>().player = this.gameObject;

    }

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.SetBool("isPage7", true);
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (start)
        {
            if(transform.position.x == finalPosition.x){
                StartCoroutine(ui.Glow(0.4f));
            }else{
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
        }
    }


    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); //raycast to see if character is on ground
        if(isGrounded && Input.GetMouseButtonDown(0) && start && doOnce)//inputs 
        {
            Jump();
        }
    }

    private void OnMouseDown()// to start the game
    {
        start = true;
        StartCoroutine(Wait());
        FindObjectOfType<Antagonist>().start = true;
    }

    public void Jump() //jump function
    {
        aS.PlayOneShot(aCJump);
        myAnimator.SetBool("isJump", true);
        rb.velocity = Vector2.up * 8f;
    }

    private IEnumerator Wait()//make sure there's a delay between clicking to start and clicking to jump
    {
        yield return new WaitForSeconds(0.1f);
        myAnimator.SetBool("isIdle", false);
        myAnimator.SetBool("berimbauGlow", false);
        myAnimator.SetBool("isRun", true);
        doOnce = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        print("Personagem collidiu com: "+collision.gameObject.name);
        if(collision.gameObject.name == "Cartwheel")
        {
            StartCoroutine(ui.Glow(0.5f));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("wtrf");
            FindObjectOfType<UI>().glow.SetBool("glow", true);
        }
    }
}
