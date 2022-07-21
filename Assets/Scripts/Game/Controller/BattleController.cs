using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public GameObject redTeamFlag;
    public GameObject blueTeamFlag;

    public GameObject redTeamEntities;
    public GameObject blueTeamEntities;

    public readonly List<HumanoidReference> redHumanoids = new List<HumanoidReference>();
    public readonly List<HumanoidReference> blueHumanoids = new List<HumanoidReference>();

    public Material redMaterial;
    public Material blueMaterial;

    public float respawnDelay = 10;

    private Spawner redSpawner;
    private Spawner blueSpawner;

    void Start()
    {
        int humanoidLayer = LayerMask.NameToLayer("Humanoid");

        redSpawner = redTeamEntities.GetComponent<Spawner>();
        redSpawner.SpawnBots(10, Teams.Type.Red, this);
        FindHumanoids(redTeamEntities, redHumanoids, humanoidLayer);
       

        blueSpawner = blueTeamEntities.GetComponent<Spawner>();
        blueSpawner.SpawnBots(10, Teams.Type.Blue, this);
        FindHumanoids(blueTeamEntities, blueHumanoids, humanoidLayer);
    }

    private void FindHumanoids(GameObject parent, List<HumanoidReference> store, int compareLayer)
    {
        foreach(Transform child in parent.transform)
        {
            if(child.gameObject.layer == compareLayer)
            {
                HumanoidReference reference = new HumanoidReference();
                reference.gameObject = child.gameObject;
                reference.life = child.gameObject.GetComponent<HumanoidLife>();
                store.Add(reference);
            }
        }
    }

    void Update()
    {
        UpdateEnemiesFrom(redHumanoids, redSpawner);
        UpdateEnemiesFrom(blueHumanoids, blueSpawner);
    }

    public void UpdateEnemiesFrom(List<HumanoidReference> references, Spawner spawner)
    {
        foreach(HumanoidReference reference in references)
        {
            if(!reference.life.isAlive)
            {
                reference.deadTime += 1 * Time.deltaTime;
                if(reference.deadTime >= respawnDelay)
                {
                    reference.deadTime = 0;
                    reference.life.SetLife(100);        

                    reference.gameObject.transform.position = spawner.RandomPoint();   
                }
            }
        }
    }

    public readonly List<GameObject> tmpList = new List<GameObject>();
    public List<GameObject> ListEnemies(Teams.Type myTeam){
        tmpList.Clear();

        switch(myTeam)
        {
            case Teams.Type.Red:
            {
                ListAllAliveEnemiesFrom(blueHumanoids, tmpList);
                break;
            }
            case Teams.Type.Blue:
            {            
                ListAllAliveEnemiesFrom(redHumanoids, tmpList);
                break;
            }
            default:
            {
                throw new System.Exception("The teams type " + myTeam.ToString() + " was not registered here!");
            }
        }
        return tmpList;
    }
    public void ListAllAliveEnemiesFrom(List<HumanoidReference> references, List<GameObject> output)
    {
        foreach(HumanoidReference reference in references)
        {
            if(reference.life.isAlive)
            {
                output.Add(reference.gameObject);
            }
        }
    }

    public Material MaterialOf(Teams.Type team)
    {
        switch(team)
        {
            case Teams.Type.Red:
            {
                return redMaterial;
            }
            case Teams.Type.Blue:
            {
                return blueMaterial;
            }
            default:
            {
                throw new System.Exception("The teams type " + team.ToString() + " was not registered here!");
            }
        }
    }
}
