using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Enemy/Actions/Patrol")]
    public class GoToFlagAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            EnemyData enemyData = stateMachine.machineData as EnemyData;
            NavMeshAgent navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();

            navMeshAgent.SetDestination(enemyData.otherTeamFlag.transform.position);
        }
    }
