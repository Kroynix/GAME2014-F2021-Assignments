using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierBehaviour : MonoBehaviour
{
    public ShieldBar shield;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Barrier Started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
        {
          if(col.gameObject.name == "EnemyBullet(Clone)")
          {
              shield.DamageShield(2);
          }
     }
    
}
