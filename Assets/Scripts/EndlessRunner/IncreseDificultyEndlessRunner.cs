using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreseDificultyEndlessRunner : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;

    private CameraMovement camMovement;
    private PlayerMovement playerMovement;
    private PlayerCombat playerCombat;
    private EnemySpawnerEndlessRunner enemySpawner;

    [SerializeField] private float timeIncreaseDificulty;
    [SerializeField] private float playerSpeed_Rate;
    [SerializeField] private float attackRate_Rate;
    [SerializeField] private float camSpeed_Rate;
    [SerializeField] private float enemySpawn_Rate;

    [SerializeField] private float minPlayerSpeed;
    [SerializeField] private float maxPlayerSpeed;
    [SerializeField] private float minAttackRate;
    [SerializeField] private float maxAttackRate;
    [SerializeField] private float minCamSpeed;
    [SerializeField] private float maxCamSpeed;
    [SerializeField] private float minEnemySpawnRate;
    [SerializeField] private float maxEnemySpawnRate;

    [SerializeField] private float actualTime;

    // Start is called before the first frame update
    void Start() {
        camMovement = cam.GetComponent<CameraMovement>();
        playerMovement = player.GetComponent<PlayerMovement>();
        playerCombat = player.GetComponent<PlayerCombat>();
        enemySpawner = enemy.GetComponent<EnemySpawnerEndlessRunner>();
        actualTime = 0f;
    }

    // Update is called once per frame
    void Update() {
        if (actualTime >= timeIncreaseDificulty) {
            //Debug.Log("Difficulty increased");
            if (playerMovement.playerSpeed > minPlayerSpeed && playerMovement.playerSpeed < maxPlayerSpeed)
                playerMovement.playerSpeed += playerSpeed_Rate;
            if (playerCombat.attackRate > minAttackRate && playerCombat.attackRate < maxAttackRate)
                playerCombat.attackRate += attackRate_Rate;
            if (camMovement.camSpeed > minCamSpeed && camMovement.camSpeed < maxCamSpeed)    
                camMovement.camSpeed += camSpeed_Rate;
            if (enemySpawner.spawnRate > minEnemySpawnRate && enemySpawner.spawnRate < maxEnemySpawnRate)
                enemySpawner.spawnRate += enemySpawn_Rate;

            actualTime = 0f;
        } else {
            actualTime += Time.deltaTime;
        }
    }
}
