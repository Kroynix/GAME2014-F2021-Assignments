/*
Nathan Nguyen
George Brown College
Assignment 2 - GAME2014-F2021

101268067
10/23/2021

Description:
Controls the Player Movement and Shooting

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class m_PlayerBehaviour : MonoBehaviour
{
    [Header("Player Movement")] 
    [Range(0.0f, 200.0f)]
    public float HorizontalForce;
    public Bounds bounds;
    public Joystick joystick;


    [Header("Player Attack")]
    public Transform bulletSpawn;
    public float secondDelay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shoot());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        float inputX = joystick.Horizontal;
        float inputY = joystick.Vertical;

        transform.position += new Vector3(inputX,inputY,0) * HorizontalForce * Time.deltaTime; 
    }

    private void CheckBounds()
    {
        // Left Boundary
        if (transform.position.x < bounds.min)
        {
            transform.position = new Vector2(bounds.min, transform.position.y);
        }

        // Right Boundary
        if (transform.position.x > bounds.max)
        {
            transform.position = new Vector2(bounds.max, transform.position.y);
        }

        // Right Boundary
        if (transform.position.y > bounds.ymax)
        {
            transform.position = new Vector2(transform.position.x, bounds.ymax);
        }

        // Right Boundary
        if (transform.position.y < bounds.ymin)
        {
            transform.position = new Vector2(transform.position.x, bounds.ymin);
        }

    }

    public void playerPowerup()
    {
        if(secondDelay < 0.1 && secondDelay > 0.05)
        {
            secondDelay -= 0.01f;
        }
        else if(secondDelay > 0.1)
        {
            secondDelay -= 0.1f;
        }

        
    }

    IEnumerator shoot()
    {
        while(FindObjectOfType<GameManager>().gameRunning)
        {
            yield return new WaitForSeconds(secondDelay);
            BulletManager.Instance().GetBullet(bulletSpawn.position, BulletType.PLAYER);
            FindObjectOfType<AudioManager>().Play("Shoot");
        }
    }



}
