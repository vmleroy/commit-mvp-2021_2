using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionDetection : MonoBehaviour
{
    private GroundSpawner groundSpawner; 
    private Transform groundPosition;

    // Start is called before the first frame update
    void Start() { 
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        groundPosition = gameObject.GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update() { }

    void OnTriggerExit2D (Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            Debug.Log ("Is player");
            GameObject player = collider.gameObject;
            if (player.transform.position.x > (groundPosition.position.x + 12f) ) {
                Debug.Log ("New ground");
                groundSpawner.SpawnGround();
                GetComponentInParent<GroundDestroy>().GroundDelete();
            }
        }
    }
}
