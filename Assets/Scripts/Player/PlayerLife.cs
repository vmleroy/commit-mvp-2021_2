using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public bool playerIsDead;

    // Start is called before the first frame update
    void Start() {
        playerIsDead = false;
    }

    // Update is called once per frame
    void Update() { }

    public void Die () {
        //Debug.Log("Die :(");
        FindObjectOfType<GameManager>().GameOver();    
        playerIsDead = true;    
        animator.SetBool("isDead", true);      
    }
}
