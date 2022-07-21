using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaterial(Material material)
    {
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        mr.material = material;
    }
}
