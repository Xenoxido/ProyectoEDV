using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int numberCoinsCollected;
    // Start is called before the first frame update
    void Start()
    {
        numberCoinsCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CoinCollected()
    {
        ++numberCoinsCollected;
    }

    public int getCoinsCollected()
    {
        return numberCoinsCollected;
    }

}
