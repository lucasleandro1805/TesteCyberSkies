using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject capturedBy;
    private Vector3 startPosition;

    private Rigidbody rb;

    void Start()
    {
        startPosition = transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.detectCollisions = true;
    }

    void Update()
    {
        if(capturedBy != null)
        {
            transform.position = new Vector3(
                capturedBy.transform.position.x,
                transform.position.y,
                capturedBy.transform.position.z);

            if(!capturedBy.activeSelf)
            {
                capturedBy = null;
            }
        } else {
            transform.position = startPosition;
        }
    }

    public void Capture(GameObject humanoid)
    {
        capturedBy = humanoid;
        rb.detectCollisions = false;
    }

    public void DropAtDeposit()
    {
        capturedBy = null;
        rb.detectCollisions = true;
    }
}
