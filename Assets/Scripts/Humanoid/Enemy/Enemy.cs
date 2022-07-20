using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Humanoid
{
    private NavMeshAgent agent;
    private GameObject targetFlag;

    private EnemyWorker[] workers = new EnemyWorker[]{
        new GoToTheFlag()
    };
    
    public void Start()
    {
        base.Start();

        agent = GetComponent<NavMeshAgent>();
    }

    
    public void Update()
    {
        base.Update();

        agent.destination = targetFlag.transform.position;
    }

    public void SetTargetFlag(GameObject targetFlag)
    {
        this.targetFlag = targetFlag;
    }
}
