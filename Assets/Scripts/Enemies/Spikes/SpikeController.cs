using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    [SerializeField] private float speed;
    
    // Start is called before the first frame update
    void Start() { }
    
    void Update() { }

    public void _Destroy () {
        Debug.Log("Broke spike");
        Destroy(gameObject);        
    }

    void OnTriggerEnter2D (Collider2D collider) { 
        if ( collider.CompareTag("Player") ) {
            PlayerLife player = collider.gameObject.GetComponent<PlayerLife>();
            player.Die();
        }        
    }
}
