using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{ public int force = 50;
    


    
    void OnCollisionEnter2D(Collision2D col) {
               
        if (col.gameObject.name == "Player")
        {
            col.gameObject.SendMessage("Hurt", force);
            SendMessage("flip");
        }
    }
}
