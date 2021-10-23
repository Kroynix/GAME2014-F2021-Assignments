using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : BulletBehaviour
{
    void Start()
    {
        type = BulletType.ENEMY;

        bulletVelocity = new Vector3(0.0f, -0.1f, 0.0f);
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
          if(col.gameObject.name == "Barrier")
          {
            FindObjectOfType<ShieldBar>().DamageShield(2);
            BulletManager.Instance().ReturnBullet(this.gameObject, type);
          }
          else if(col.gameObject.name == "Player")
          {
            FindObjectOfType<ShieldBar>().DamageShield(0.5f);
            BulletManager.Instance().ReturnBullet(this.gameObject, type);
          }

    }

}
