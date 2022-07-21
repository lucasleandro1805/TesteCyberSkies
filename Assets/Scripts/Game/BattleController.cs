using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public GameObject redTeamFlag;
    public GameObject blueTeamFlag;

    public GameObject redTeamEntities;
    public GameObject blueTeamEntities;

    public List<GameObject> redHumanoids;
    public List<GameObject> blueHumanoids;

    public Material redMaterial;
    public Material blueMaterial;

    void Start()
    {
        int humanoidLayer = LayerMask.NameToLayer("Humanoid");

        Spawner redSpawner = redTeamEntities.GetComponent<Spawner>();
        redSpawner.SpawnBots(10, Teams.Type.Red, this);
        FindHumanoids(redTeamEntities, redHumanoids, humanoidLayer);
       

        Spawner blueSpawner = blueTeamEntities.GetComponent<Spawner>();
        blueSpawner.SpawnBots(10, Teams.Type.Blue, this);
        FindHumanoids(blueTeamEntities, blueHumanoids, humanoidLayer);
    }

    private void FindHumanoids(GameObject parent, List<GameObject> store, int compareLayer)
    {
        foreach(Transform child in parent.transform)
        {
            if(child.gameObject.layer == compareLayer)
            {
                store.Add(child.gameObject);
            }
        }
    }

    void Update()
    {
        
    }

    public List<GameObject> ListEnemies(Teams.Type myTeam){
        switch(myTeam)
        {
            case Teams.Type.Red:
            {
                return blueHumanoids;
            }
            case Teams.Type.Blue:
            {
                return redHumanoids;
            }
            default:
            {
                throw new System.Exception("The teams type " + myTeam.ToString() + " was not registered here!");
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
