using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class FSMAction : ScriptableObject
{
    public abstract void Execute(BaseStateMachine stateMachine);
}