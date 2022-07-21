using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseStateMachine : MonoBehaviour
{
    public MachineData machineData;

    public BaseState currentState;

    private void Awake()
    {
        if(machineData == null)
        {
            throw new System.Exception("Missing data for FSM at object " + transform.name);
        }
        machineData = Instantiate(machineData);
    }

    private void Update()
    {
        if(currentState == null)
        {
            throw new System.Exception("Missing state for FSM at object " + transform.name);
        }
        currentState.Execute(this);
    }
}