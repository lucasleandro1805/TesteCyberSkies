using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightSensor : MonoBehaviour
{
    private readonly BattleControllerReference battleController = new BattleControllerReference();

    private GameObject chaseEnemy;
    private EnemyConfig enemyConfig;

    private void Awake()
    {
        battleController.Start();
        enemyConfig = gameObject.GetComponent<EnemyConfig>();
    }

    public GameObject FindVisibleEnemy(EnemyData data)
    {
        Vector3 myPos = gameObject.transform.position;
        Vector3 myViewDirection = gameObject.transform.forward;

        GameObject nearestEnemy = null;
        float nearestEnemyDistance = 0;
        float nearestEnemyAngle = 0;
        float nearestWeight = 0;
        foreach(GameObject enemyObj in battleController.Get().ListEnemies(data.myTeam))
        {
            Vector3 enemyPos = enemyObj.transform.position;

            Vector3 direction = enemyPos - myPos;
            float distance = direction.magnitude;
            if(distance < enemyConfig.maxVisionDistance)
            {
                float angle = Vector3.Angle(Vector3.Normalize(direction), myViewDirection);
                if(angle < enemyConfig.maxVisionAngle)
                {
                    Ray ray = new Ray(myPos, direction);

                    if (Physics.Raycast(ray, out var hit, enemyConfig.maxVisionDistance))
                    {
                        if(hit.collider.gameObject == enemyObj)
                        {
                            float weight = distance + angle;
                            if(nearestEnemy == null || weight < nearestWeight)
                            {
                                nearestEnemy = enemyObj;
                                nearestEnemyDistance = distance;
                                nearestEnemyAngle = angle;
                                nearestWeight = weight;
                            }
                        }
                        
                    }                   
                }
            }
        }
        chaseEnemy = nearestEnemy;
        return nearestEnemy;
    }

    private void OnDrawGizmos()
    {
        if(chaseEnemy == null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * enemyConfig.maxVisionDistance);

            Vector3 letSideRay = Quaternion.Euler(0, -enemyConfig.maxVisionAngle, 0) * this.transform.forward;
            Gizmos.DrawLine(this.transform.position, this.transform.position + letSideRay * enemyConfig.maxVisionDistance);

            Vector3 RightSideRay = Quaternion.Euler(0, enemyConfig.maxVisionAngle, 0) * this.transform.forward;
            Gizmos.DrawLine(this.transform.position, this.transform.position + RightSideRay * enemyConfig.maxVisionDistance);
        }
        else
        {
            Gizmos.color = Color.yellow;

            Vector3 myPos = gameObject.transform.position;
            Vector3 enemyPos = chaseEnemy.transform.position;
            Vector3 direction = enemyPos - myPos;
            Gizmos.DrawLine(this.transform.position, this.transform.position + direction);            
        }
    }
}