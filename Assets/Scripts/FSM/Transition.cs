using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "FSM/Transition")]
public sealed class Transition : ScriptableObject
{
    public Decision decision;
    public BaseState trueState;
    public BaseState falseState;

    public void Execute(BaseStateMachine stateMachine)
    {
        if(decision.Decide(stateMachine) && !(trueState is RemainInState))
            stateMachine.currentState = trueState;
        else if(!(falseState is RemainInState))
            stateMachine.currentState = falseState;
    }
}
