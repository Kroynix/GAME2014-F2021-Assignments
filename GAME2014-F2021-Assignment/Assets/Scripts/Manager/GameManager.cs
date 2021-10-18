using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GameObjects
    public Timer timer;
    public GameObject EnemyPrefab;
    public float respawnTime = 1.0f;


    private int enemyCount = 5;
    private int currentEnemy = 0;
    private Vector2 screenBoarder;

    

    // Start is called before the first frame update
    void Start()
    {
        timer.startTime();
        StartCoroutine(enemyWave());
        screenBoarder = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void spawnEnemy()
    {
        GameObject e = Instantiate(EnemyPrefab) as GameObject;
        e.transform.position = new Vector2(e.transform.position.x, screenBoarder.y + 1);
    }

    IEnumerator enemyWave()
    {
        while(currentEnemy != enemyCount){
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
            currentEnemy += 1;
        }
    }
}
