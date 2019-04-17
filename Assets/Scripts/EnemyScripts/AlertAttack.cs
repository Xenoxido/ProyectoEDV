

using UnityEngine;
using System.Collections;


public class AlertAttack : MonoBehaviour
{


    public void AlertObserver(int i)
    {
        if (i == 1)
            SendMessage("isAttacking", true);
        if (i == 0)
            SendMessage("isAttacking", false);
    }
}
