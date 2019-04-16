﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSceneLine : MonoBehaviour
{
    public Transform from;
    public Transform to;

    // Start is called before the first frame update
    private void OnDrawGizmosSelected()
    {
        if(from!=null && to!= null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(from.position, to.position);
        }
    }
    
        
    
}
