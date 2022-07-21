using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    public BattleController battleController;
    public GameObject menuObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAsRedTeam()
    {
        battleController.StartBattle(Teams.Type.Red);
    }

    public void StartAsBlueTeam()
    {
        battleController.StartBattle(Teams.Type.Blue);
    }

    public void OnBattleStarted()
    {
        menuObject.SetActive(false);
    }

    public void OnBattleEnded()
    {
        menuObject.SetActive(true);
    }
}
