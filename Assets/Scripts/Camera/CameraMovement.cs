using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameManager gameManager;
    
    public float camSpeed;

    // Start is called before the first frame update
    void Start() { 
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update() {   
        if(!gameManager.gameOver && gameManager.stageRunning)
            transform.position += new Vector3 (Time.deltaTime * camSpeed, 0f, 0f);
    }
}
