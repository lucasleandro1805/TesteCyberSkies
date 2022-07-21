using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "FSM/Transition")]
public sealed class Transition : ScriptableObject
{
    public Decision decision;
    public BaseState onTrueState;

    public BaseState trueState;
    public BaseState falseState;

    public bool IsActive(BaseStateMachine stateMachine)
    {
        if(decision == null)
        {
            stateMachine.currentState = onTrueState;
            return true;
        }

        if(decision.Decide(stateMachine) && !(onTrueState is RemainInState))
        {
            stateMachine.currentState = onTrueState;
            return true;
        }
        return false;
    }
}
