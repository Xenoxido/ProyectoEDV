using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsCollider : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.SendMessage("ObjectCollected", gameObject.tag);
        Destroy(gameObject);
    }
}
