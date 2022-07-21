using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HumanoidReference
{
    public GameObject gameObject;
    public HumanoidLife life;

    public float deadTime = 0;
    public int kills;
    public int deaths;
}
