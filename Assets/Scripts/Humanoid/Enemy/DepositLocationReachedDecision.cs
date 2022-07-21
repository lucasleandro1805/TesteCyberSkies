using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decisions/DepositLocationReached")]
public class DepositLocationReachedDecision : Decision
{
    public override bool Decide(BaseStateMachine stateMachine)
    {
        EnemyData enemyData = stateMachine.machineData as EnemyData;
        
        GameObject area = enemyData.flagDepositLocation;

        float scaX = area.transform.localScale.x;
        float scaZ = area.transform.localScale.z;

        float minX = area.transform.position.x - scaX/2;
        float minZ = area.transform.position.z - scaZ/2;

        float maxX = area.transform.position.x + scaX/2;
        float maxZ = area.transform.position.z + scaZ/2;

        Vector3 myPos = stateMachine.transform.position;
        if(myPos.x >= minX && myPos.x <= maxX)
        {
            if(myPos.z >= minZ && myPos.z <= maxZ)
            {
                return true;
            }            
        }
        return false;
    }
}