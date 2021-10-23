/*
Nathan Nguyen
George Brown College
Assignment 2 - GAME2014-F2021

101268067
10/23/2021

Description:
Handles Enemy Behaviour

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy Movement")] 
    public Bounds movementBounds;
    public Bounds startingRange;
    public float ShipSpeed;

    [HideInInspector]
    public int Health = 10;
    
    [Header("Bullets")] 
    public Transform bulletSpawn;
    public int frameDelay;

    private float startingPoint;
    private float randomSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        randomSpeed = Random.Range(movementBounds.min, movementBounds.max);
        startingPoint = Random.Range(startingRange.min, startingRange.max);
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = new Vector2(Mathf.PingPong(Time.time, randomSpeed) + startingPoint, transform.position.y);
       transform.position -= new Vector3(0,Time.deltaTime * ShipSpeed, 0);

       if(Health <= 0)
       {
           FindObjectOfType<GameManager>().enemyDestroyed();
           Destroy(gameObject);
       }

    }

    void FixedUpdate()
    {
        if (Time.frameCount % frameDelay == 0)
        {
            BulletManager.Instance().GetBullet(bulletSpawn.position);
            FindObjectOfType<AudioManager>().Play("Shoot");
        }
    }

    public void EnemyHit()
    {
        Health -= 10;
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Barrier"))
        {
            FindObjectOfType<ShieldBar>().DamageShield(30);
            FindObjectOfType<GameManager>().enemyHitShield();
            Destroy(gameObject);
        }
        else if (col.CompareTag("Player"))
        {
            FindObjectOfType<ShieldBar>().DamageShield(50);
            FindObjectOfType<GameManager>().enemyHitShield();
            Destroy(gameObject);
        }

    }

}
