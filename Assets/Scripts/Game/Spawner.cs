using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject botPrefab;
    public GameObject area;

    public void SpawnBots(int count, Teams.Type myTeam, BattleController battleController, GameObject otherTeamFlag, GameObject flagDepositLocation)
    {    
        for(int x = 0; x < count; x ++)
        {
            GameObject bot = Instantiate(botPrefab);
            bot.transform.position = RandomPoint();
            bot.transform.rotation = GetSpawnRotation();
            bot.transform.SetParent(gameObject.transform);
            
            BaseStateMachine stateMachine = bot.GetComponent<BaseStateMachine>();
            EnemyData enemyData = stateMachine.machineData as EnemyData;
            enemyData.otherTeamFlag = otherTeamFlag;
            enemyData.myTeam = myTeam;
            enemyData.config = bot.GetComponent<EnemyConfig>();
            enemyData.flagDepositLocation = flagDepositLocation;
            
            EnemyModel enemyModel = bot.GetComponent<EnemyModel>();
            enemyModel.SetMaterial(battleController.MaterialOf(myTeam));         

            FlagCapturer flagCapturer = bot.GetComponent<FlagCapturer>();
            flagCapturer.wantedFlag = otherTeamFlag;    
        }
    }

    public Vector3 RandomPoint(){
        float scaX = area.transform.localScale.x;
        float scaZ = area.transform.localScale.z;

        float minX = area.transform.position.x - scaX/2;
        float minZ = area.transform.position.z - scaZ/2;

        float maxX = area.transform.position.x + scaX/2;
        float maxZ = area.transform.position.z + scaZ/2;

        return new Vector3(Random.Range(minX, maxX), area.transform.position.y, Random.Range(minZ, maxZ));
    }

    public Vector3 GetSpawnDirection()
    {
        return area.transform.forward;
    }

    public Quaternion GetSpawnRotation()
    {
        return Quaternion.LookRotation(GetSpawnDirection());
    }
}
