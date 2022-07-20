using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject botPrefab;
    public GameObject area;
    public GameObject otherTeamFlag;

    void Start()
    {
        SpawnBots(10);
    }
    
    void Update()
    {
        
    }

    public void SpawnBots(int count)
    {    
        for(int x = 0; x < count; x ++)
        {
            GameObject bot = Instantiate(botPrefab);
            bot.transform.position = RandomPoint();
            bot.transform.SetParent(gameObject.transform);

            Enemy enemyScript = bot.GetComponent<Enemy>();
            enemyScript.SetTargetFlag(otherTeamFlag);
        }
    }

    private Vector3 RandomPoint(){
        float scaX = area.transform.localScale.x;
        float scaZ = area.transform.localScale.z;

        float minX = area.transform.position.x - scaX/2;
        float minZ = area.transform.position.z - scaZ/2;

        float maxX = area.transform.position.x + scaX/2;
        float maxZ = area.transform.position.z + scaZ/2;

        return new Vector3(Random.Range(minX, maxX), area.transform.position.y, Random.Range(minZ, maxZ));
    }
}
