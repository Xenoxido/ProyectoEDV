using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{ public int force = 10;

    
    void OnCollisionEnter2D(Collision2D col) {
        SendMessage("flip");        
        if (col.gameObject.name == "Player")
        {
            col.gameObject.SendMessage("Hurt", 10);
        }
    }
}
