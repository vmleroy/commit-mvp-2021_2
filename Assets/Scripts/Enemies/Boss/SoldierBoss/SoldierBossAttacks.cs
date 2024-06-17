using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBossAttacks : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject grenade;
    [SerializeField] Transform firepoint;
    [SerializeField] Transform hgFirepoint; 

    // Start is called before the first frame update
    void Start() { 
        NormalShot();
        ThrowGranade();
    }

    // Update is called once per frame
    void Update() { }

    public void NormalShot () {
        GameObject normalBullet = bullet;
        normalBullet.GetComponent<BulletController>().bulletSpeed = 5f;
        Instantiate(normalBullet, new Vector3(firepoint.position.x, firepoint.position.y, firepoint.position.z), Quaternion.identity);
    }

    public void ThrowGranade () {
        Instantiate(grenade, new Vector3(hgFirepoint.position.x, hgFirepoint.position.y, hgFirepoint.position.z), Quaternion.identity);
    }

}
