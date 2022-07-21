using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Enemy/Actions/DropTheFlag")]
    public class DropTheFlagAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            EnemyData enemyData = stateMachine.machineData as EnemyData;
            FlagCapturer flagCapturer = stateMachine.GetComponent<FlagCapturer>();

            flagCapturer.DropAtDeposit();
        }
    }
