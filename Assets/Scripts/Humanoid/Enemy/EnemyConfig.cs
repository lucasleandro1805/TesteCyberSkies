using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConfig : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float maxVisionDistance = 20;
    public float maxVisionAngle = 60;
    public Vector2 shotDelayRange = new Vector2(1,3);

    public Vector2 damageRange = new Vector2(5,30);

    public GameObject muzzlePosition;
    public GameObject shotSoundPrefab;
    public GameObject muzzlePrefab;
}
