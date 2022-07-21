using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Actions/Chase")]
    public class ChaseAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            var navMeshAgent = stateMachine.GetComponent<UnityEngine.AI.NavMeshAgent>();
            var enemySightSensor = stateMachine.GetComponent<EnemySightSensor>();

            navMeshAgent.SetDestination(enemySightSensor.Player.position);
        }
    }