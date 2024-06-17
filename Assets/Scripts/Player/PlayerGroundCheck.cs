using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start() { 
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter2D (Collider2D collider) {
            //Debug.Log("Enter " + collider.name);
        // Ground collision
        if (collider.gameObject.layer == 6) {
            playerMovement.isGrounded = true;
            playerMovement.animator.SetBool("isGrounded", true);
        }
    }

    void OnTriggerStay2D (Collider2D collider) {
            //Debug.Log("Stay " + collider.name);
        // Ground collision
        if (collider.gameObject.layer == 6) {
            playerMovement.isGrounded = true;
            playerMovement.animator.SetBool("isGrounded", true);
        }            
    }

    void OnTriggerExit2D (Collider2D collider) {
            //Debug.Log("Exit " + collider.name);
        // Ground collision
        if (collider.gameObject.layer == 6) {
            playerMovement.isGrounded = false;
            playerMovement.animator.SetBool("isGrounded", false);
        }
    }
}
