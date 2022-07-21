using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class BattleController : MonoBehaviour
{
    public GameObject redTeamFlag;
    public GameObject blueTeamFlag;

    public GameObject redTeamDeposit;
    public GameObject blueTeamDeposit;

    public GameObject redTeamEntities;
    public GameObject blueTeamEntities;

    public readonly List<HumanoidReference> redHumanoids = new List<HumanoidReference>();
    public readonly List<HumanoidReference> blueHumanoids = new List<HumanoidReference>();

    public Material redMaterial;
    public Material blueMaterial;

    public float respawnDelay = 10;
    public float maxGameSeconds = 300;

    public int redKills;
    public int blueKills;
    public int redCaptures;
    public int blueCaptures;
    public int redPoints;
    public int bluePoints;

    public GameObject menuCamera;
    public HUDController hudController;

    public GameObject player;
    private StarterAssetsInputs playerInputs; 

    private Spawner redSpawner;
    private Spawner blueSpawner;

    private int humanoidLayer;
    public float gameLifeTime;
    private bool isRunning;


    void Start()
    {
        humanoidLayer = LayerMask.NameToLayer("Humanoid");
        redSpawner = redTeamEntities.GetComponent<Spawner>();
        blueSpawner = blueTeamEntities.GetComponent<Spawner>();

        playerInputs = player.GetComponent<StarterAssetsInputs>();        
        playerInputs.cursorLocked = false;
        playerInputs.cursorInputForLook = false;
    }

    void Update()
    {
        if(isRunning)
        {
            UpdateEnemiesFrom(redHumanoids, redSpawner);
            UpdateEnemiesFrom(blueHumanoids, blueSpawner);

            gameLifeTime -= 1 * Time.deltaTime;

            if(gameLifeTime <= 0)
            {
                FinishBattle();
            }
        }
    }

    public void StartBattle(Teams.Type selectedTeam)
    {        
        isRunning = true;
        Cursor.visible = false;
        playerInputs.cursorLocked = true;
        playerInputs.cursorInputForLook = true;
        Cursor.lockState = CursorLockMode.Locked;
        menuCamera.SetActive(false);
        player.SetActive(true);
        int redBots = 10;
        int blueBots = 10;
        switch(selectedTeam)
        {
            case Teams.Type.Red:
            {
                redBots--;
                player.transform.position = redSpawner.RandomPoint();
                player.transform.rotation = redSpawner.GetSpawnRotation();
                break;
            }
            case Teams.Type.Blue:
            {            
                blueBots--;
                player.transform.position = blueSpawner.RandomPoint();
                player.transform.rotation = blueSpawner.GetSpawnRotation();
                break;
            }
            default:
            {
                throw new System.Exception("The teams type " + selectedTeam.ToString() + " was not registered here!");
            }
        }

        redSpawner.SpawnBots(redBots, Teams.Type.Red, this, blueTeamFlag, redTeamDeposit);
        FindHumanoids(redTeamEntities, redHumanoids, humanoidLayer);
       
        blueSpawner.SpawnBots(blueBots, Teams.Type.Blue, this, redTeamFlag, blueTeamDeposit);
        FindHumanoids(blueTeamEntities, blueHumanoids, humanoidLayer);

        hudController.OnBattleStarted();
        gameLifeTime = maxGameSeconds;
    }

    public void FinishBattle()
    {
        isRunning = false;
        Cursor.visible = true;
        playerInputs.cursorLocked = false;
        playerInputs.cursorInputForLook = false;
        Cursor.lockState = CursorLockMode.None;
        menuCamera.SetActive(true);
        player.SetActive(false);
        redHumanoids.Clear();
        blueHumanoids.Clear();

        ClearEntities(redTeamEntities);
        ClearEntities(blueTeamEntities);

        hudController.OnBattleEnded();
    }

    private void ClearEntities(GameObject parent)
    {
        foreach(Transform child in parent.transform)
        {
            Destroy(child.gameObject);        
        }
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
                reference.life.battleController = this;
                store.Add(reference);
            }
        }
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

    public void RegisterKill(GameObject from, GameObject killed)
    {
        {
            bool foundAtRed = false;
            foreach(HumanoidReference reference in redHumanoids)
            {
                if(reference.gameObject == from)
                {
                    reference.kills++;
                    redKills++;
                    redPoints++;
                    foundAtRed = true;
                    break;
                }
            }
            if(!foundAtRed)
            {
                foreach(HumanoidReference reference in blueHumanoids)
                {
                    if(reference.gameObject == from)
                    {
                        reference.kills++;
                        blueKills++;
                        bluePoints++;
                        break;
                    }
                }
            }
        }

        foreach(HumanoidReference reference in redHumanoids)
        {
            if(reference.gameObject == killed)
            {
                reference.deaths++;
                return;
            }
        }
        foreach(HumanoidReference reference in blueHumanoids)
        {
            if(reference.gameObject == killed)
            {
                reference.deaths++;
                return;
            }
        }
    }
}
