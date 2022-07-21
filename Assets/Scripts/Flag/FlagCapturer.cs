using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCapturer : MonoBehaviour
{
    public GameObject wantedFlag;
    public GameObject capturedFlag;
    private HumanoidLife humanoidLife;

    void Start()
    {
        humanoidLife = gameObject.GetComponent<HumanoidLife>();
        humanoidLife.AddListener(OnLifeChangedListener);
    }

    public void OnLifeChangedListener(float life)
    {
        if(!humanoidLife.isAlive)
        {
            capturedFlag = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == wantedFlag)
        {
            capturedFlag = other.gameObject;
            capturedFlag.SendMessage("Capture", gameObject);            
        }
    }

    public void DropAtDeposit()
    {
        if(capturedFlag == null)
        {
            throw new System.Exception("Can't drop a null flag");
        }
        capturedFlag.SendMessage("DropAtDeposit");
        capturedFlag = null;        
    }

    public bool HasTheFlag()
    {
        return capturedFlag != null;
    }
}
