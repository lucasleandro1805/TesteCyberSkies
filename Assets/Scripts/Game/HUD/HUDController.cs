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
    public TextMeshProUGUI timeCounterViewer;

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

        {
            float minutes = battleController.gameLifeTime / 60f;
            int intMinutes = (int)minutes;
            float seconds = (minutes - intMinutes)*60f;
            int intSeconds = (int)seconds;
            timeCounterViewer.text = intMinutes + ":" + intSeconds.ToString("00");
        }
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
