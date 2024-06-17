using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    private Visibility visibility;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start() {
        visibility = gameObject.GetComponent<Visibility>();
    }

    // Update is called once per frame
    void Update() {
        Movement();
    }

    void Movement () {
        if(visibility.isVisible)
            transform.position -= new Vector3 (Time.deltaTime * speed, 0f);
    }

    public void _Destroy () {
        Debug.Log("Slime killed");
        Destroy(gameObject);
    }

    void OnTriggerEnter2D (Collider2D collider) {
        if ( collider.CompareTag("Player") ) {
            PlayerLife player = collider.gameObject.GetComponent<PlayerLife>();
            player.Die();
        } 
    }

}
