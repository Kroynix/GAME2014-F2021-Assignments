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

    }

    void Update()
    {
        transform.position -= new Vector3(0,Time.deltaTime * FallSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().PowerupPickup();
            FindObjectOfType<m_PlayerBehaviour>().playerPowerup();
            Destroy(gameObject);
        }
        else if(col.CompareTag("Barrier"))
        {
            FindObjectOfType<ShieldBar>().DamageShield(20);
            Destroy(gameObject);
        }



    }
}
