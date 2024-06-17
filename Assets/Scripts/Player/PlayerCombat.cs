using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{    

    [SerializeField] Rigidbody2D body;
    [SerializeField] Animator animator;
    [SerializeField] Transform attackPoint;
    [SerializeField] PlayerLife playerLife;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] LayerMask projectileLayer;
    [SerializeField] HUDComponents HUD;

    HitDelayBar hitDelayBar;

    [SerializeField] float attackDamage;
    private float attackCD = 0f;
    public float attackRange = 0.5f;
    public float attackRate = 2f;


    void Start() {   
        HUD = FindObjectOfType<HUDComponents>();
        
        hitDelayBar = HUD.hitDelayBar;
        // Set max value hit delay bar
        hitDelayBar.SetMaxHitDelay(1);
        attackCD = attackRate;
    }

    // Update is called once per frame
    void Update() {
        if (!playerLife.playerIsDead)
            CheckIfCanAttack();
    }

    void CheckIfCanAttack () {
        // Get the attack input if the cooldown is greater than attackRate
        if (attackCD >= attackRate) {
            //hitDelayBar.TriggerVisibility(false);
            if (Input.GetButtonDown("Attack")) {
                Attack();
                attackCD = 0;
                //hitDelayBar.TriggerVisibility(true);
            }   
        } else {                   
            // Cooldown     
            attackCD += Time.deltaTime;
            attackCD = Mathf.Clamp(attackCD, 0f, attackRate);

            // Update hit delay bar
            hitDelayBar.SetHitDelay(attackCD/attackRate);
        }
    }

    void Attack() {
        // Set the animation
        animator.SetTrigger("isAttacking");

        // Detect enimies in range
        Collider2D [] enimiesHit = Physics2D.OverlapCircleAll (attackPoint.position, attackRange, enemyLayer);
        Collider2D [] projectilesHit = Physics2D.OverlapCircleAll (attackPoint.position, attackRange, projectileLayer);

        // Apply damage
        foreach (Collider2D enemy in enimiesHit) {
            if(enemy.gameObject.CompareTag("Spikes")) {
                enemy.GetComponent<SpikeController>()._Destroy();
            } if (enemy.gameObject.CompareTag("Slime")) {
                enemy.GetComponent<SlimeController>()._Destroy();
            } if (enemy.gameObject.CompareTag("Duck")) {
                enemy.GetComponent<DuckController>()._Destroy();
            } if (enemy.gameObject.CompareTag("Bullet")) {
                enemy.GetComponent<BulletController>()._Destroy();
            } if (enemy.gameObject.CompareTag("Boss")) {
                enemy.GetComponent<BossLifeController>().SufferDamage(attackDamage);
            }
        }

        foreach (Collider2D projectile in projectilesHit) {
            if (projectile.gameObject.CompareTag("Grenade")) {
                projectile.GetComponent<GrenadeController>().Knockback();
            } if (projectile.gameObject.CompareTag("Bullet")) {
                projectile.GetComponent<BulletController>()._Destroy();
            } 
        }

    }

    void Knockback (float powerX, float powerY) {
        body.AddForce(new Vector2(powerX, powerY), ForceMode2D.Impulse);
    }

    // Enemy head detection
    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.layer == 9) {                
            if (collision.gameObject.CompareTag("Slime")) {
                collision.gameObject.GetComponentInParent<SlimeController>()._Destroy();
                Knockback(0, 3);
            }
        }
    }

    void OnDrawGizmosSelected  () {
        if(attackPoint == null) {
            return;
        }
        Gizmos.DrawWireSphere (attackPoint.position, attackRange);
    }
}
