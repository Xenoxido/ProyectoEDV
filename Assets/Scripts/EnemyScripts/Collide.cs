using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{ public int force = 50;
    private int currentForce;


    void Start()
    {
        currentForce = force;
    }
    


    
    void OnCollisionEnter2D(Collision2D col) {
               
        if (col.gameObject.name == "Player")
        {
            col.gameObject.SendMessage("Hurt", currentForce);
            SendMessage("flip");
        }
    }

    void changeForce(int newforce)
    {
        Debug.Log(newforce);
        if (newforce == 0)
        {
            
            currentForce = force;
        }
        else
        {
            currentForce = newforce;
        }

    }
}
