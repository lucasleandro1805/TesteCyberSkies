using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/AlwaysTrue")]
public class AlwaysTrueDecision : Decision
{
    public override bool Decide(BaseStateMachine stateMachine)
    {
        return true;
    }
}