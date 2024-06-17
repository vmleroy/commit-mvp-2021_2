using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDelayBar : MonoBehaviour
{
    [SerializeField] public Slider slider;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Vector3 positionOffset;


    void Start () {
        slider.gameObject.SetActive(true);
    }

    void Update () {
        // Follow player position
        transform.position = new Vector3 (playerPosition.position.x + positionOffset.x, playerPosition.position.y + positionOffset.y, playerPosition.position.z + positionOffset.z);
    }

    public void SetMaxHitDelay (float nextTimerHit) {
        slider.maxValue = nextTimerHit;
        slider.value = nextTimerHit;
    }

    public void SetHitDelay (float timer) {
        slider.value = timer;
    }

    public void TriggerVisibility (bool visible) {
        slider.gameObject.SetActive(visible);
    }

}

