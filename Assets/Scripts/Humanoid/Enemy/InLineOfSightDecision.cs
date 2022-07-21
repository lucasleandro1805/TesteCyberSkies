using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/In Line Of Sight")]
public class InLineOfSightDecision : Decision
{
    public override bool Decide(BaseStateMachine stateMachine)
    {
        EnemyData enemyData = stateMachine.machineData as EnemyData;
        var enemyInLineOfSight = stateMachine.GetComponent<EnemySightSensor>();

        GameObject visibleEnemy = enemyInLineOfSight.FindVisibleEnemy(enemyData);
        return visibleEnemy != null;
    }
}