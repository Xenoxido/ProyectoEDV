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
        }
    }
}
