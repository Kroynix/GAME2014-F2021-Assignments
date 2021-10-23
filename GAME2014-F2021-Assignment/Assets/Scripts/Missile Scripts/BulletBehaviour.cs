/*
Nathan Nguyen
George Brown College
Assignment 2 - GAME2014-F2021

101268067
10/23/2021

Description:
Handles Bullet Behaviours General

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBehaviour : MonoBehaviour
{
    public BulletType type;

    [Header("Bullet Movement")]
    public Vector3 bulletVelocity;
    public Bounds bulletBounds;

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += bulletVelocity;
    }


    protected virtual void CheckBounds()
    {
        // check bottom boundary
        if (transform.position.y < bulletBounds.max)
        {
            BulletManager.Instance().ReturnBullet(this.gameObject, type);
        }

        // check bottom boundary
        if (transform.position.y > bulletBounds.min)
        {
            BulletManager.Instance().ReturnBullet(this.gameObject, type);
        }
    }
}
