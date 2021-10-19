using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_PlayerBehaviour : MonoBehaviour
{
    [Header("Player Movement")] 
    [Range(0.0f, 200.0f)]
    public float HorizontalForce;
    public Bounds bounds;
    public Joystick joystick;


    [Header("Player Attack")]
    public Transform bulletSpawn;
    public int frameDelay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
        CheckFire();
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
    }

    public void CheckFire()
    {
        if ((Time.frameCount % frameDelay == 0))
        {
            BulletManager.Instance().GetBullet(bulletSpawn.position, BulletType.PLAYER);
        }
    }

    public void playerPowerup()
    {
        if(frameDelay > 5)
        {
            frameDelay -= 5;
        }
        else if (frameDelay == 5)
        {
            frameDelay = 1;
        }
        
    }



}
