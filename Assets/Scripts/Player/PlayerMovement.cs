using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private PlayerLife playerLife;
    private GameManager gameManager;
    public Animator animator;
    
    [SerializeField] private float jumpForce;
    [SerializeField] private bool canMove;     
    public float playerSpeed;
    public bool isGrounded;  

    void Start () {
        gameManager = FindObjectOfType<GameManager>();
        animator.SetBool("isMoving", true);
        canMove = true;
    }

    // Update is called once per frame
    void Update() {   
        if (canMove) {     
            Jump();

            if (!gameManager.bossTime) AutoWalk();            
            else Walk();

            if(playerLife.playerIsDead) canMove = false;        
        }
    }

    void Jump () {
        // Jump if the player is standing on the ground
        if (Input.GetButtonDown("Jump") && isGrounded) {      
            body.AddForce (new Vector2(0f, jumpForce), ForceMode2D.Impulse);            
        }
    }

    void AutoWalk() {                
        // Get the input and set the velocity
        Vector3 movement = new Vector3 (Input.GetAxis("Horizontal"), 0f);                    
        // Setting the walking animation 
        if ( Input.GetAxis("Horizontal") > 0 ) {
            animator.SetBool("isMoving", true);
            transform.position += movement * Time.deltaTime * playerSpeed;
        }  
        if ( Input.GetAxis("Horizontal") < 0 ) {
            animator.SetBool("isMoving", true);
            transform.position += movement * Time.deltaTime * (playerSpeed - 3f);
        }                         
    }

    void Walk () {
        // Get the input and set the velocity
        Vector3 movement = new Vector3 (Input.GetAxis("Horizontal"), 0f);                    
        // Setting the walking animation 
        if ( Input.GetAxis("Horizontal") > 0 ) {
            animator.SetBool("isMoving", true);
            transform.position += movement * Time.deltaTime * playerSpeed;
        }  
        if ( Input.GetAxis("Horizontal") < 0 ) {
            animator.SetBool("isMoving", true);
            transform.position += movement * Time.deltaTime * playerSpeed;
        }
        if ( Input.GetAxis("Horizontal") == 0 ) {
            animator.SetBool("isMoving", false);
        }
    }
    
}
