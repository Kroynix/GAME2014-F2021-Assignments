using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy Movement")] 
    public Bounds movementBounds;
    public Bounds startingRange;
    public float ShipSpeed;
    public int Health = 10;
    
    [Header("Bullets")] 
    public Transform bulletSpawn;
    public int frameDelay;

    private float startingPoint;
    private float randomSpeed;
    
    private GameObject ManagerHost;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        ManagerHost = GameObject.FindGameObjectWithTag("GameMaster");
        gm = ManagerHost.GetComponent<GameManager>();
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
           gm.enemyDestroyed();
           Destroy(gameObject);
       }

    }

    void FixedUpdate()
    {
        if (Time.frameCount % frameDelay == 0)
        {
            BulletManager.Instance().GetBullet(bulletSpawn.position);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("PlayerProjectile"))
        {
            Health -= 5;
        }
    }

}
