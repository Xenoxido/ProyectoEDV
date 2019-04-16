using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private Animator _anim;
    private BoxCollider2D _collider;

    public Transform playerDetection;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider2D>();
        _collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        var localVelocity = transform.InverseTransformDirection(GetComponent<Rigidbody2D>().velocity);
        Vector2 dir = new Vector2(localVelocity.x, 0);
        dir.Normalize();
        RaycastHit2D straightRay = Physics2D.Raycast(playerDetection.position, dir, 3f);                 
        if (straightRay.collider && straightRay.collider.tag == "Player")
        {
            Debug.Log("found player");            
            if (_anim.GetBool("Attacks") == false)
            {
                SendMessage("attack",true);
                _anim.SetBool("Attacks", true);                

            }
        }
        else
        {
            if (_anim.GetBool("Attacks") == true)
            {
                SendMessage("attack", false);
                _anim.SetBool("Attacks", false);
            }

        }
    }
}
