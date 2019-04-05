﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private Rigidbody2D _body;
    public float speed = 4.5f;
    private bool right;
    // Start is called before the first frame update
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _body = GetComponent<Rigidbody2D>();
        right = true;
        
        
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
        movement = movement * deltaX * speed;
        movement.y = _body.velocity.y;
              
        
        _body.velocity = movement;
    }

    private void flip()
    {

        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        right = transform.localScale.x > 0;
    }
}
