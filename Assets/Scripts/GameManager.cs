using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] CameraMovement cam;
    [SerializeField] PlayerMovement player;

    [SerializeField] float restartDelay;
    [SerializeField] List<string> gameModeNames;
    [SerializeField] List<bool> gameModeActive;
    [SerializeField] List<GameObject> bossList;
    int stageIndex;

    public bool bossTime;
    public bool stageRunning;
    public bool gameOver;

    // Start is called before the first frame update
    void Start() { 
        cam = FindObjectOfType<CameraMovement>();
        player = FindObjectOfType<PlayerMovement>();

        for (int i=0; i<gameModeActive.Count; i++) {
            if (gameModeActive[i] == true) stageIndex = i;
        }
    }

    // Update is called once per frame
    void Update() { 
        stageSize();
    }

    public void GameOver () {
        if (!gameOver) {
            gameOver = true;
            Debug.Log("Game over");
            Invoke("Restart", restartDelay);       
        }
    }

    public void Restart () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void stageSize () {
        switch (stageIndex) {
            case 1:
                if ( (gameModeActive[1] == true) && (cam.transform.position.x >= 100) )
                    if(!bossTime) {
                        bossTime = true;
                        stageRunning = false;
                        Debug.Log("Boss Time");
                        player.transform.position = new Vector3(cam.transform.position.x - 8f, player.transform.position.y, player.transform.position.z);
                        Instantiate(bossList[0], new Vector3 (cam.transform.position.x + 7f, cam.transform.position.y - 1.65f, player.transform.position.z), Quaternion.Euler(0f, 180f, 0f));
                        Restart();
                    }
            break;
            //default: Debug.Log("Is endless runner"); break;
        }      
    }

}
