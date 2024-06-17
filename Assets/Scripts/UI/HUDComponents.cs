using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDComponents : MonoBehaviour
{

    public HitDelayBar hitDelayBar;
    public Score score;
    public BossLifeBar bossLifeBar;

    public void DisableOrEnableHitDelayBar () {
        if (hitDelayBar.slider.IsActive()) 
            hitDelayBar.TriggerVisibility(false);
        else
            hitDelayBar.TriggerVisibility(true);
    }

    public void DisableOrEnableScore () {
        if (score.scoreText.IsActive()) 
            score.TriggerVisibility(false);
        else
            score.TriggerVisibility(true);
    }

    public void DisableOrEnableBossLifeBar () {
        if (bossLifeBar.slider.IsActive()) 
            bossLifeBar.TriggerVisibility(false);
        else
            bossLifeBar.TriggerVisibility(true);
    }
}
