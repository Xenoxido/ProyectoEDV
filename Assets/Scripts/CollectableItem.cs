using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private GameManager gameManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Item collected: " + itemName);
        gameManager.SendMessage("CoinCollected");
        Destroy(this.gameObject);
    }
}
