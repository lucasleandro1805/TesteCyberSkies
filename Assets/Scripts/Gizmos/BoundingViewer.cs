using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingViewer : MonoBehaviour
{
    public Color color = new Color(1, 0, 0, 0.5f);
    
    void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
