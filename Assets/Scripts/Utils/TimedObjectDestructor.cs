using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectDestructor : MonoBehaviour
{
    public float timeOut = 3f;

    private float lifeTime;
    
    void Update()
    {
        lifeTime += 1 * Time.deltaTime;
        if(lifeTime >= timeOut)
        {
            Destroy(gameObject);
        }
    }
}
