using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public bool winText;
    public float movementSpeed;
    public float jumpForce = 1;
    private Rigidbody2D rigidBody;
    public GameManager theGM;
    public float airTime;
    public float airTimeCounter;
    public bool grounded;
    public LayerMask whatIsGrd;
    public Transform grdChecker;
    public float grdCheckerRad;
    private bool canMove;

    public int scoreValue;

    public int life;
    public Text lives;
    public Text score;

    public bool win;
    public bool lose;
    public GameObject flagpole;
    private float coins;

    public Text winner;

    
    private Animator animator;
    CharacterController controller;
    void Start()
    {
        rigidBody=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        
        airTimeCounter=airTime;
        score.text = ("Mario       "+scoreValue.ToString()+"       World 1-1");
        win=false;
        lose=false;
        life=1;
        winText=false;
        winner.text=("");


    }
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0)*Time.deltaTime*movementSpeed;

        //to swith character direction but it switched the map's instead
       /* if(!Mathf.Approximately(0, movement))
            transform.rotation=movement>0?Quaternion.Euler(0,180,0):Quaternion.identity;*/
      /* if(Input.GetButtonDown("Jump") && Mathf.Abs(rigidBody.velocity.y)<0.001f)
        {                                                                                       old jump mechanic
            rigidBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }*/

        if(Input.GetAxisRaw("Horizontal")>0.5f || Input.GetAxisRaw("Horizontal")<-0.5f)
        {
            canMove=true;
        }
        if(winner==true)
        {
            
        }
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(grdChecker.position,grdCheckerRad,whatIsGrd);
        MovePlayer();
        Jump();
        
    }

    
    
    void MovePlayer()
    {
        if(canMove)
        {
            rigidBody.velocity=new Vector2(Input.GetAxisRaw("Horizontal")*movementSpeed,rigidBody.velocity.y);

            animator.SetFloat("Speed",Mathf.Abs(rigidBody.velocity.x));
            if(rigidBody.velocity.x>0)
            {
                transform.localScale=new Vector2(.6f,.6f);
            }
            else if(rigidBody.velocity.x<0)
            {
                transform.localScale=new Vector2(-.6f,.6f);
            }
        }
    }
    
        
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.collider.tag=="Enemy")
        {
            life-=1;
        }

        if(collision.collider.tag=="Flagpole")
        {
            win=true;

        }
    }

    void Jump()
    {
       /* if(Input.GetButtonDown("Jump") && Mathf.Abs(rigidBody.velocity.y)<0.001f)
        { 
            rigidBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            if(airTimeCounter>0)
            {
                
            }
        }*/
        if(grounded==true)
        {
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.X))
        {
            if(airTimeCounter>0)
            {
                rigidBody.velocity=new Vector2(rigidBody.velocity.x,jumpForce);
            }
        }
        }
        if(Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.X))
        {
            if(airTimeCounter>0)
            {
                rigidBody.velocity=new Vector2(rigidBody.velocity.x,jumpForce);
                airTimeCounter-=Time.deltaTime;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space)||Input.GetKeyUp(KeyCode.X))
        {
            airTimeCounter=0;
        }
        if(grounded)
        {
            airTimeCounter=airTime;
        }

        animator.SetBool("Grounded", grounded);
    }
    void Run()
    {
        while(Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.Z))
        {
            movementSpeed+=2;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Enemy")
        {   
            //still needs lives to implement the if statement
            //theGM.GameOver();
        }
        if(other.transform.tag=="Coin")
        {
            Destroy(other.gameObject);
            scoreValue+=1;
        }
        if(other.transform.tag=="Flagpole")
        {
            Destroy(other.gameObject);
            winText=true;
            controller.enabled=false;
        }
        
    }
}
