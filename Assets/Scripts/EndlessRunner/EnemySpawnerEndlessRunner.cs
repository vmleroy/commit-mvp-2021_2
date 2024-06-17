using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerEndlessRunner : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform enemySpawnerPos;
    [SerializeField] private List<GameObject> enemy;    

    [SerializeField] private float posY;
    public float spawnRate;    

    private float nextSpawn;
    private float posX;
    
    // Start is called before the first frame update
    void Start() {
        nextSpawn = spawnRate;    
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    // Try to spawn the enemy, and if can spawn, spawn it
    void Spawn () {
        if (Time.time > nextSpawn) {
            int index = Random.Range(0, enemy.Count);
            GameObject enemyToSpawn = enemy[index];

            posY = enemyToSpawn.gameObject.transform.position.y;            

            if (enemyToSpawn.CompareTag("Spikes")) {
                posX = enemySpawnerPos.transform.position.x - 3f;
            } else if (enemyToSpawn.CompareTag("Slime")) {
                posX = enemySpawnerPos.transform.position.x;
            } else if (enemyToSpawn.CompareTag("Duck")) {
                posX = enemySpawnerPos.transform.position.x;
            } else {
                return ;
            }                   
            
            Vector2 whereToSpawn = new Vector2 (posX, posY);
            Instantiate (enemyToSpawn, whereToSpawn, Quaternion.identity);

            nextSpawn = Time.time + spawnRate;
        }
    }
}
