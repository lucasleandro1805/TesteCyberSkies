using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    public BattleController battleController;
    public GameObject menuCanvasObject;
    public GameObject gameCanvasObject;
    public TextMeshProUGUI redPointsViewer;
    public TextMeshProUGUI bluePointsViewer;

    void Start()
    {
        menuCanvasObject.SetActive(true);
        gameCanvasObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        redPointsViewer.text  = "Points: " +battleController.redPoints  + "";
        bluePointsViewer.text = "Points: " +battleController.bluePoints + "";
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
        menuCanvasObject.SetActive(false);
        gameCanvasObject.SetActive(true);
    }

    public void OnBattleEnded()
    {
        menuCanvasObject.SetActive(true);
        gameCanvasObject.SetActive(false);
    }
}
