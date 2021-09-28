/*
Nathan Nguyen
George Brown College
Assignment 1 - GAME2014-F2021
101268067
9/26/2021
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_PlayerBehaviour : MonoBehaviour
{    
    private Vector2 moveInput;

    [SerializeField]
    public float moveSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = new Vector2(transform.position.x,  transform.position.y);

        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(inputX,inputY,0) * moveSpeed * Time.deltaTime; 
    }
}
