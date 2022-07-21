using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseState : ScriptableObject
{
    public virtual void Execute(BaseStateMachine machine) { }
}