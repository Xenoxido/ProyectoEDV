using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsCollider : MonoBehaviour
{
    private UIController canvas;
    private GameManager manager;
   
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIController>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canvas.SendMessage("activeImage", gameObject.tag);
            manager.SendMessage("ObjectCollected", gameObject.tag);
            Destroy(gameObject);
        }
    }
}
