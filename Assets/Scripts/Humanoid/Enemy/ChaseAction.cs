using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Actions/Chase")]
public class ChaseAction : FSMAction
{
    public override void Execute(BaseStateMachine stateMachine)
    {
        EnemyData enemyData = stateMachine.machineData as EnemyData;
        var navMeshAgent = stateMachine.GetComponent<UnityEngine.AI.NavMeshAgent>();
        var enemySightSensor = stateMachine.GetComponent<EnemySightSensor>();

        GameObject enemy = enemySightSensor.FindVisibleEnemy(enemyData);    
        if(enemy != null)
        {
            navMeshAgent.SetDestination(enemy.transform.position);
        }
    }
}