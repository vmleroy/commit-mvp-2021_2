using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossLifeBar : MonoBehaviour
{
    [SerializeField] public Slider slider;
    [SerializeField] bool startActivated = false;

    void Start () {
        slider.gameObject.SetActive(startActivated);
    }

    public void SetMaxValue (float bossLife) {
        slider.maxValue = bossLife;
    }
    
    public void SetValue (float bossLife) {
        slider.value = bossLife;
    }

    public void TriggerVisibility (bool visible) {
        slider.gameObject.SetActive(visible);
    }
}
