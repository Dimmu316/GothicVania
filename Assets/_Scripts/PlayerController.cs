using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    Rigidbody2D rigidbody2D;
    public float moveDirection;
    public bool grounded = true;
    public Animator anim;
    public float jumpSpeed = 1f;
    public bool facingRigth = true;
    public SpriteRenderer spriteR;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Horizontal") < 0)
        {
            spriteR.flipX = true;
            anim.SetBool("IsRun", true);
            anim.SetBool("IsIdle", false);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            spriteR.flipX = false;
            anim.SetBool("IsRun", true);
            anim.SetBool("IsIdle", false);
        }
       

        if (Input.GetButtonDown("Jump") )
        {
            rigidbody2D.AddForce(new Vector2(0, jumpSpeed));
            anim.SetBool("IsJump", true);
                       
        }else
        {
            grounded = false;
        }
    }
    
    void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(moveDirection * speed, rigidbody2D.velocity.y);
         
    }
}

