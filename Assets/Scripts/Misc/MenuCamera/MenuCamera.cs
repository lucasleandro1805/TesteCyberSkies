using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    public GameObject points;

   
    public float minDistance = 1f;
    public float lookSpeed = 2f;
    public float moveSpeed = 1f;

    private float currentSpeed;
    private int currentPoint;
    private float currentLookSpeed;


    void Start()
    {
        Transform wantedPoint = points.transform.GetChild(currentPoint);
        this.transform.position = wantedPoint.position;
    }

    
    void Update()
    {
        int childCount = points.transform.childCount;

        if(currentPoint >= childCount)
        {
            currentPoint = 0;
        }

        Transform wantedPoint = points.transform.GetChild(currentPoint);
        float distance = Vector3.Distance (this.transform.position, wantedPoint.position);        

        {
            Quaternion targetRotation = Quaternion.LookRotation(wantedPoint.transform.position - transform.position);
            float angleBetween = Quaternion.Angle( transform.rotation, targetRotation );   
            float wantedSpeed = (lookSpeed/100f) * angleBetween;
            currentLookSpeed = Mathf.Lerp(currentLookSpeed, wantedSpeed, 0.25f * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, currentLookSpeed * Time.deltaTime);
        }

        {
            float dis = distance + 2f;
            currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed * dis, 0.25f * Time.deltaTime);
            this.transform.Translate(0,0, currentSpeed * Time.deltaTime);
        }

        if(distance <= minDistance)
        {
            currentPoint++;
        }
    }
}
