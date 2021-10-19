using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{

    public float FallSpeed = 0.5f;
    private GameObject player;
    private m_PlayerBehaviour playerScript;


    void Start()
    {
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
            playerScript.playerPowerup();
            Destroy(gameObject);
        }

    }
}
