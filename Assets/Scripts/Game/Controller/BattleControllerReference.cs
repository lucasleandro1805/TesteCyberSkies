using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleControllerReference
{
      private BattleController battleController;

      public void Start()
      {
        GameObject gameController = GameObject.Find("GameController");
        if(gameController == null)
        {
            throw new System.Exception("Failed to find BattleController object!");
        }
        battleController = gameController.GetComponent<BattleController>();
        if(battleController == null)
        {
            throw new System.Exception("BattleController object doesn't have a BattleController component!");
        }
    }

    public BattleController Get()
    {
        return battleController;
    }
}
