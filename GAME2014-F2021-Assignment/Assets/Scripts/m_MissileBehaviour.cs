/*
Nathan Nguyen
George Brown College
Assignment 1 - GAME2014-F2021
101268067
9/30/2021
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_MissileBehaviour : MonoBehaviour
{
    private GameObject player;
    private Quaternion angle;
    private float CalcAngle;
    private Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        // Find Player
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //CURRENTLY IN UPDATE FOR TESTING, IN THE FUTURE WILL BE MOVED TO THE START AS THE MISSILE WILL ONLY BE MOVING IN ONE DIRECTION AND 
        //WILL NOT BE ACTIVELY SEEKING THE PLAYER

        //Find the Direction of the Player in relation to the missile
        direction = player.transform.position - transform.position;
        //Calculate the Angle between the player and the missile, Offset 90 Degree's due to Unity and how it handles angles
        CalcAngle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg - 90.0f;
        //Turn the Float into Quaternion
        angle = Quaternion.AngleAxis(CalcAngle, Vector3.forward);
        //Apply angle to transform
        transform.rotation = angle;
    }
}
