using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{

    public Transform groundDetection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D groundRay = Physics2D.Raycast(groundDetection.position,Vector2.down,1f);
        if(groundRay.collider == false)
        {
            SendMessage("flip");
            return;
        }
        var localVelocity = transform.InverseTransformDirection(GetComponent<Rigidbody2D>().velocity);
        Vector2 dir = new Vector2(localVelocity.x, 0);
        dir.Normalize();
        RaycastHit2D straightRay = Physics2D.Raycast(groundDetection.position, dir, 2f);
        if(straightRay.collider==true&&straightRay.collider.tag != "Player")
        {            
            SendMessage("flip");
        }


    }
}
