using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{

    public float FallSpeed = 0.5f;
    private GameObject player;
    private m_PlayerBehaviour playerScript;
    private GameObject ManagerHost;
    private GameManager gm;

    void Start()
    {

        ManagerHost = GameObject.FindGameObjectWithTag("GameMaster");
        gm = ManagerHost.GetComponent<GameManager>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<m_PlayerBehaviour>();
    }

    void Update()
    {
        transform.position -= new Vector3(0,Time.deltaTime * FallSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            gm.PowerupPickup();
            playerScript.playerPowerup();
            Destroy(gameObject);
        }

    }
}
