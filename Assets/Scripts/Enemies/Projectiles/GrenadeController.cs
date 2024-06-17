using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrenadeController : MonoBehaviour
{
    Visibility visibility;    
    Rigidbody2D rb;  
    
    public float throwForce;  
    bool CanDamageBoss;
    float damageToEnemy;

    // Start is called before the first frame update
    void Start() {
        CanDamageBoss = false;

        visibility = gameObject.GetComponent<Visibility>();

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(-throwForce/2, throwForce), ForceMode2D.Impulse);
    }

    public void Knockback () {
        CanDamageBoss = true;
        rb.AddForce(new Vector2(10, 5), ForceMode2D.Impulse);
    }
    
    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {                                        
            _Destroy();
            collision.gameObject.GetComponent<PlayerLife>().Die();                        
        } if (collision.gameObject.CompareTag("Boss") && CanDamageBoss) {            
            _Destroy();
            collision.gameObject.GetComponent<BossLifeController>().SufferDamage(5);                        
        }        
    }

    public void _Destroy () {
        Destroy(gameObject);
    }

}
