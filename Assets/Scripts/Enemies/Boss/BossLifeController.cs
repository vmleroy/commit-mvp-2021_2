using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLifeController : MonoBehaviour
{
    [SerializeField] float BossLife;
    [SerializeField] HUDComponents HUD;
    BossLifeBar healthBar;

    // Start is called before the first frame update
    void Start() {
        HUD = FindObjectOfType<HUDComponents>();
        //HUD.DisableOrEnableBossLifeBar();
        HUD.DisableOrEnableScore();

        healthBar = HUD.bossLifeBar;
        healthBar.SetMaxValue(BossLife);   
        healthBar.SetValue(BossLife);
    }

    // Update is called once per frame
    void Update() { }

    public void SufferDamage (float damage) {
        Debug.Log("Suffer damage");
        BossLife -= damage;
        healthBar.SetValue(BossLife);
        if (BossLife <= 0f) {
            healthBar.TriggerVisibility(false);
            HUD.DisableOrEnableScore();
            _Destroy();
        }
    }

    public void _Destroy () {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        GameObject[] grenade = GameObject.FindGameObjectsWithTag("Grenade");
        foreach (GameObject b in bullets) b.GetComponent<BulletController>()._Destroy();
        foreach (GameObject g in grenade) g.GetComponent<GrenadeController>()._Destroy();
        Destroy(gameObject);
    }
}
