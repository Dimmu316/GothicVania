using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float maxSpeed = 6.0f;
    public bool facingRigth = true;
    public float moveDirection;
    private new Rigidbody2D rigidbody2D;
    private Animator anim;
    public float jumpSpeed = 600.0f;
    public bool grounded = false;
    //public Transform groundCheck;
    //public float groundRadius = 0.2f;
    //public LayerMask whatIsGround;

    //public float knifeSpeed = 600.0f;
    //public Transform knifeSpawn;
    //public Rigidbody knifePrefab;
    //Rigidbody clone;


    // Start is called before the first frame update
    void Start()
        
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //groundCheck = GameObject.Find("GroundCheck").transform;
        //knifeSpawn = GameObject.Find("KnifeSpawn").transform;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("IsJumping");
            rigidbody2D.AddForce(new Vector2(0, jumpSpeed));
        }
    }
    
     void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(moveDirection * maxSpeed, rigidbody2D.velocity.y);
       // grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (moveDirection > 0.0f && !facingRigth)
        {
            flip();
        } else if (moveDirection < 0.0f && facingRigth)
        {
            flip();
        }
        anim.SetFloat("Speed", Mathf.Abs(moveDirection));

        if (Input.GetButton("Fire1"))
        {
            Attack();
        }
        
    }

    void flip()
    {
        facingRigth = !facingRigth;
        transform.Rotate(Vector3.up, 180.0f, Space.World);
    }

    void Attack()
    {
        anim.SetTrigger("Attacking");
        
    }

   /* public void CallFireProjectile()
    {
        clone = Instantiate(knifePrefab, knifeSpawn.position, knifeSpawn.rotation) as Rigidbody;
        clone.AddForce(knifeSpawn.transform.right * knifeSpeed);
    }*/

}
