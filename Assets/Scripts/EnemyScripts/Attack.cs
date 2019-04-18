﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private Animator _anim;
    private Rigidbody2D _body;

    public Transform playerDetection;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        var localVelocity = transform.InverseTransformDirection(GetComponent<Rigidbody2D>().velocity);
        Vector2 dir = new Vector2(localVelocity.x, 0);
        dir.Normalize();
        RaycastHit2D straightRay = Physics2D.Raycast(playerDetection.position, dir, 2f);                 
        if (straightRay.collider && straightRay.collider.tag == "Player")
        {
            Debug.Log("player");
            if (_anim.GetBool("Attacks") == false)
            {                
                _anim.SetBool("Attacks", true);
                SendMessage("stay");
            }
        }
        
    }

    private void attackAnim(int i)
    {
        if (i==1)
        {
            
            _body.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            SendMessage("run", true);
            SendMessage("changeForce", 150);
        }
        if (i == 2)
        {
            
            SendMessage("stay");
            int j = 0;
            SendMessage("changeForce", j);
        }
        if (i == 3)
        {            
            SendMessage("run", false);
            _anim.SetBool("Attacks", false);
        }
    }

    



}
