using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/HasTheFlag")]
public class HasFlagDecision : Decision
{
    public override bool Decide(BaseStateMachine stateMachine)
    {
        EnemyData enemyData = stateMachine.machineData as EnemyData;
        FlagCapturer flagCapturer = stateMachine.GetComponent<FlagCapturer>();
        return flagCapturer.HasTheFlag();
    }
}