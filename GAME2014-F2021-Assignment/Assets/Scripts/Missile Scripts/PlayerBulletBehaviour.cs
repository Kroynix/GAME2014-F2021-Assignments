/*
Nathan Nguyen
George Brown College
Assignment 2 - GAME2014-F2021

101268067
10/23/2021

Description:
Bullet Identifier for the player and behaviour specific to player

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehaviour : BulletBehaviour
{
    void Start()
    {
        type = BulletType.PLAYER;

        bulletVelocity = new Vector3(0.0f, 0.1f, 0.0f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            BulletManager.Instance().ReturnBullet(this.gameObject, type);
            other.GetComponent<EnemyBehaviour>().EnemyHit();
        }
    }
    
}
