﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    
    private Rigidbody2D _body;
    public float speed = 4.5f;
    public float runspeed = 9f;    
    private float currentSpeed;
    private bool right;
    // Start is called before the first frame update
    void Start()
    {
        
        _body = GetComponent<Rigidbody2D>();
        right = true;
        currentSpeed = speed;
        bool patrol = false;
        
        
    }  

    


    // Update is called once per frame
    void Update()
    {


        float deltaX = Time.deltaTime * 60;
         if (!right)
          {
               deltaX *= -1;              
          }
        Vector2 movement = Vector2.right;
        movement.y = _body.velocity.y;
        movement.x = movement.x * deltaX * currentSpeed;      
        
        _body.velocity = movement;
        
    }

    private void flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        right = transform.localScale.x > 0;
    }

    private void run(bool shouldRun)
    {
        if (shouldRun)
        {
            
            currentSpeed = runspeed;
        }
        else
        {
            currentSpeed = speed;
        }

    }

    private void stay()
    {
        currentSpeed = 0;
    }

    
}
