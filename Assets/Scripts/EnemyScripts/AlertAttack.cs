

using UnityEngine;
using System.Collections;


public class ExampleClass : MonoBehaviour
{
    public void AlertObserver(string s)
    {
        SendMessage("Attack");
    }
}
