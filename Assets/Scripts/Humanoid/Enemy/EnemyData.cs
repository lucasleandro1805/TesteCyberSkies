using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Data")]
public class EnemyData : MachineData
{
    public GameObject otherTeamFlag;
    public Teams.Type myTeam;
    public EnemyConfig config;
    public GameObject flagDepositLocation;

    public float shotDelay = 3f;
}
