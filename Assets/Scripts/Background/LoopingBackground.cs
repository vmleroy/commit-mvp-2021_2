using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{

    private GameManager gameManager;

    [SerializeField] private float backgroundSpeed;
    [SerializeField] private Renderer backgroundRenderer;

    // Start is called before the first frame update
    void Start() { 
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update() {
        if(!gameManager.gameOver && gameManager.stageRunning)
            backgroundRenderer.material.mainTextureOffset += new Vector2 ((backgroundSpeed * Time.deltaTime), 0f);
    }
}
