using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "FSM/State")]
public sealed class State : BaseState
{
    public List<FSMAction> action = new List<FSMAction>();
    public List<Transition> transitions = new List<Transition>();

    public override void Execute(BaseStateMachine machine)
    {
        foreach (var action in action)
        {
            action.Execute(machine);
        }

        foreach(var transition in transitions)
        {
            if(transition.IsActive(machine))
            {
                break;
            }
        }
    }
}