using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Timer")] 
    public Timer timer;

    [Header("Score")] 
    public Text ScoreBox;

    [Header("Player Reference")] 
    public m_PlayerBehaviour player;

    [Header("Enemy Wave")] 
    public GameObject EnemyPrefab;
    public float respawnTime = 1.0f;
    public int enemyCount = 5;

    [Header("Power-Up Wave")] 
    public GameObject PowerupPrefab;
    public float powerupRespawn;


    private int currentEnemy = 0;
    private Vector2 screenBoarder;




    
    // Game Over Scene
    [Header("Game Over")]
    public GameObject GameOverScene;
    public Text EndScore_Enemys;
    public Text EndScore_Time;
    public Text EndScore_Total;
    

    // Pause Handling
    [HideInInspector]
    public bool gameRunning = true;

    // Score Handling
    private int Score = 0;
    private int totalTime = 0;
    private int destroyedShips = 0;
    private int PowPickup;



    //Enemy Difficulty Scale
    private int DifficultyUp = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        // Set TimeScale
        Time.timeScale = 1.0f;
        timer.startTime();


        // Start Coroutines
        StartCoroutine(enemyWave());
        StartCoroutine(powerupWave());
        StartCoroutine(updateScore());


        ScoreBox.text = "Score: " + Score;
        screenBoarder = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }


    // Update is called once per frame
    void Update()
    {
        // Update the Score Box to Reflect current score
        ScoreBox.text = "Score: " + Score;
        Debug.Log(currentEnemy != enemyCount && gameRunning);

        if(DifficultyUp == 5)
        {
            enemyCount += 1;
            DifficultyUp = 0;

            if(respawnTime != 0.25)
            {
                respawnTime -= 0.25f;
            }
        }

    }


    public void gameEnded()
    {
        Time.timeScale = 0.0f;
        gameRunning = false;

        GameOverScene.SetActive(true);
        EndScore_Enemys.text = "Enemies Killed: " + destroyedShips +  " x 100";
        EndScore_Time.text = "Time: " + totalTime + " x 20";
        EndScore_Total.text = "Total Score: " + Score;
    }


    public void enemyHitShield()
    {
        currentEnemy -= 1;
    }


    // Score Tracking for Enemy Destroyed and Powerups
    public void enemyDestroyed()
    {
        currentEnemy -= 1;

        // Keep Track of Destroyed Ships
        destroyedShips += 1;
        DifficultyUp += 1;
        Score += 100;
    }

    public void PowerupPickup()
    {
        PowPickup += 1;
        Score += 10;
    }



    // Spawn Functions
    private void spawnEnemy()
    {
        GameObject e = Instantiate(EnemyPrefab) as GameObject;
        e.transform.position = new Vector2(e.transform.position.x, screenBoarder.y + 1);
    }

    private void spawnPowerup()
    {
        GameObject p = Instantiate(PowerupPrefab) as GameObject;
        p.transform.position = new Vector2(Random.Range(-2.1f,2.1f), screenBoarder.y + 1);
    }


    #region
    /// <Summary>
    /// All Coroutines
    /// Enemy Wave spawns a new Enemy every "EnemyCount"
    /// PowerupWave spawns a new powerup every "powerupRespawn
    /// UpdateScore keeps track of the current score due to time for the player
    ///      and keeps track of the total elapsed Time
    /// </Summary>

    IEnumerator enemyWave()
    {
        while(gameRunning)
        {
            yield return new WaitForSeconds(respawnTime);
            if(currentEnemy != enemyCount)
            {
                spawnEnemy();
                currentEnemy += 1;
            }
        }
    }

    IEnumerator powerupWave()
    {  
        //Check if the player Frame delay is not 1, If it is 1 stop spawning new PowerUps
        while(player.secondDelay != 0.05 && gameRunning)
        {
            yield return new WaitForSeconds(powerupRespawn);
            spawnPowerup();
        }

    }

    IEnumerator updateScore()
    {
        while(gameRunning)
        {
            yield return new WaitForSeconds(1.0f);
            // Increment Score and Total Time
            Score += 20;
            totalTime += 1;
        }
    }

#endregion
}
