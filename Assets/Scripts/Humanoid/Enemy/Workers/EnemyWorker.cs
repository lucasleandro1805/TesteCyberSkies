using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWorker
{
    public void Update()
    {
        
    }

    public bool ShouldExecute(){
        throw new System.Exception("Override this method!");
    }
}
