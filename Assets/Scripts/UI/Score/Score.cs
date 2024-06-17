using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField] private Transform cam;
    [SerializeField] public Text scoreText;

    void Start() {
        scoreText.gameObject.SetActive(true);
    }

    void Update() {
        scoreText.text = cam.position.x.ToString("0");
    }

    public void TriggerVisibility (bool visible) {
        scoreText.gameObject.SetActive(visible);
    }
    
}
