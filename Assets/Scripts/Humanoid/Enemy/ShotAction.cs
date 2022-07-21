using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Enemy/Actions/Shot")]
public class ShotAction : FSMAction
{
    public override void Execute(BaseStateMachine stateMachine)
    {
        EnemyData enemyData = stateMachine.machineData as EnemyData;
        NavMeshAgent navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
        EnemySightSensor enemySightSensor = stateMachine.GetComponent<EnemySightSensor>();

        GameObject enemy = enemySightSensor.FindVisibleEnemy(enemyData);    
        if(enemy != null)
        {
            navMeshAgent.SetDestination(enemy.transform.position);
            SetWalkSpeed(navMeshAgent);

            if(enemyData.shotDelay > 0)
            {
                enemyData.shotDelay -= 1 * Time.deltaTime;
                if(enemyData.shotDelay <= 0)
                {
                    enemyData.shotDelay = Random.Range(enemyData.config.shotDelayRange.x, enemyData.config.shotDelayRange.y);
                    ShotBullet(enemy, enemyData, stateMachine.gameObject);
                }
            }        
        }
    }

    public void ShotBullet(GameObject enemy, EnemyData enemyData, GameObject myObject)
    {            
        object[] sendMessageArguments = new object[2];
        sendMessageArguments[0] = Random.Range(enemyData.config.damageRange.x, enemyData.config.damageRange.y);
        sendMessageArguments[1] = myObject;
        enemy.SendMessage("ApplyDamage", sendMessageArguments);
    }

    public void SetWalkSpeed(NavMeshAgent navMeshAgent)
    {
        if(navMeshAgent.speed > 0)
        {
            navMeshAgent.speed -= 3f * Time.deltaTime;
        } 
        else 
        {
            navMeshAgent.speed = 0;
        }
    }
}