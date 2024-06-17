using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Visibility visibility;

    public float bulletSpeed;  

    // Start is called before the first frame update
    void Start() {
        visibility = gameObject.GetComponent<Visibility>();
    }

    // Update is called once per frame
    void Update() {
        if (visibility.isVisible)
            transform.position -= new Vector3 (Time.deltaTime * bulletSpeed, 0f);
    }

    public void _Destroy () {
        //Debug.Log("Bullet Destroyed");
        Destroy(gameObject);
    }

    void OnTriggerEnter2D (Collider2D collider) {
        if ( collider.CompareTag("Player") ) {
            collider.gameObject.GetComponent<PlayerLife>().Die();
            _Destroy();
        } 
    }

}
