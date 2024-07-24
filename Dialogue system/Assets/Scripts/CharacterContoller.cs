using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContoller : MonoBehaviour
{

    public float moveSpeed = 1.0f;
    public float jumpSpeed = 1.0f;
    private bool isGrounded;
    private Rigidbody2D rb;
   

    private Animator anim;


    private void Awake()
    {
        //grab refrences for rigidbody and animator
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (DialougeManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        // Get input from horizontal axis (A/D keys or Left/Right arrow keys)
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        //flip-flop movement
        if (moveInput > 0.01f)
            transform.localScale = new Vector3(10,10,10);
        else if (moveInput < -0.01f)
            transform.localScale = new Vector3(-10, 10, 10);

        // Jump movement
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            jump();
            
        }
        
       
            

        //set animator parameters
        anim.SetBool("Run",moveInput != 0);
        
        

    }

    void jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        isGrounded = false;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
           isGrounded = true;
    }

}
