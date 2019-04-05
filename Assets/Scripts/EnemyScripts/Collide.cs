using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{ public int force = 50;

    
    void OnCollisionEnter2D(Collision2D col) {
        SendMessage("flip");        
        if (col.gameObject.name == "Player")
        {
            
            col.gameObject.SendMessage("Hurt", force);
            Vector3 dir =
            transform.position - col.gameObject.transform.position;
            Debug.Log(dir);
            Vector2 norm =(new Vector2(dir.x, dir.y).normalized)*-1;
            norm.y += 1;
            norm = norm*force / 10;
            
            
            col.rigidbody.AddForce(norm , ForceMode2D.Impulse);
          
        }
    }
}
