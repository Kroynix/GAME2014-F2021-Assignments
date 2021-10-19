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


    
}
