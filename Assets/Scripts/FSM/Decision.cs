using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Decision : ScriptableObject
{
    public abstract bool Decide(BaseStateMachine state);
}