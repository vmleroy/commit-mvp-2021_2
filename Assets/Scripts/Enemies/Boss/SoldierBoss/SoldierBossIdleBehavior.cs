using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBossIdleBehavior : StateMachineBehaviour
{

    int randomNumber;
    [SerializeField] float timer;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        timer = Random.Range(minTime, maxTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (timer <= 0) {
            randomNumber = Random.Range(0,2);            
            if (randomNumber == 0) animator.SetTrigger ("Shoot");
            else animator.SetTrigger ("HG");            
        } else {
            timer -= Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
    }
}
