using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    [SerializeField] private List<GameObject> grounds;
    [SerializeField] private Vector3 firstSpawnPoint;
    private Vector3 nextSpawnPoint;

    // Start is called before the first frame update
    void Start() { 
        nextSpawnPoint = firstSpawnPoint;
        for (int i=0; i<2; i++) {
            SpawnGround();
        }
    }

    // Update is called once per frame
    void Update() { }

    public void SpawnGround () {
        int index = Random.Range(0, grounds.Count);
        GameObject groundToSpawn = grounds[index];

        GameObject newGround = Instantiate (groundToSpawn, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = newGround.transform.GetChild(0).position;
        nextSpawnPoint.x += 24f;
    }
}
