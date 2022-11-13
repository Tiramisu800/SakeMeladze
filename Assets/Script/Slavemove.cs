using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Slavemove : MonoBehaviour
//object name "Slave"
{
    
   
    private Rigidbody2D rb;
    private Animator anim; //slave animation

    private enum State { idle, run, jump, falling, hurt};
    private State state = State.idle;
    private Collider2D coll;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float speed=5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int tokens = 0;
    [SerializeField] private Text tokensText;
    [SerializeField] private float hurtForce = 10f;
    [SerializeField] private int health;
     //public Joystick joystick;

   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if(state != State.hurt)
        {
            Movement();
        }

        //float verticalMove = joystick.Vertical;


        //Jump // verticalMove >= .5f
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(Ground)) 
        {
            rb.velocity = Vector2.up * jumpForce;
            state = State.jump;

            AudioManager.instance.PlaySFX("jump");
        }


        VelocityState();
        anim.SetInteger("State", (int)state);

    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 1f, Ground);
        Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }

    //Tokens collect
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collectable")
        {
            Destroy(collision.gameObject);
            tokens += 1;
            tokensText.text = tokens.ToString();

            anim.SetBool("Taken", true);
            AudioManager.instance.PlaySFX("token");
        }
    }
   

    //enemy controler
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            if (state == State.falling)
            {

                Destroy(other.gameObject);
            }
            else
            {
                state = State.hurt;
                if(other.gameObject.transform.position.x > transform.position.x)
                {
                    //enemy is to right
                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
                }
                else
                {
                    //enemy is to left
                    rb.velocity = new Vector2(hurtForce, rb.velocity.y);
                }
            }
            
        }
    }


    private void VelocityState() //for changing animation
    {
        if (state == State.jump)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(Ground))
            {
                state = State.idle;
            }
        }
        
        else if (Mathf.Abs(rb.velocity.x)>2f) 
        {
            state = State.run;
        }
        else
        {
            state = State.idle;
        }
    }

    private void Movement() {
        //{

        //    float moveInput = joystick.Horizontal; //arrows
        //    rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //}
        float hDirection = Input.GetAxis("Horizontal"); //arrows


        if (hDirection > 0) //go to -->
        {
            rb.velocity = new Vector2(speed, rb.velocity.y); //speed
            transform.localScale = new Vector2(1, 1); //inverse of slave

        }
        else if (hDirection < 0) //go to <--
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y); //speed 
            transform.localScale = new Vector2(-1, 1); //inverse of slave

        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
