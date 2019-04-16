using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour    
{
    private Animator _anim;

    public Transform playerDetection;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        var localVelocity = transform.InverseTransformDirection(GetComponent<Rigidbody2D>().velocity);
        Vector2 dir = new Vector2(localVelocity.x, 0);
        dir.Normalize();
        RaycastHit2D straightRay = Physics2D.Raycast(playerDetection.position, dir, 6f);        
        if (straightRay.collider && straightRay.collider.tag == "Player")
        {
            if (_anim.GetBool("Sees") == false)
            {
                SendMessage("run", true);
                _anim.SetBool("Sees", true);
            }
        }
        else
        {
            if (_anim.GetBool("Sees") == true)
            {
                SendMessage("run", false);
                _anim.SetBool("Sees", false);
            }

        }
    }
}
