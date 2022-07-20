using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Humanoid
{
    private CharacterController controller;
    public bool enableGravity = true;
    public float gravity = -9.81f;
    private Vector3 moveDir = new Vector3();
    private float verticalSpeed = 0f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

   
    void Update()
    {
        moveDir.Set(0,0,0);

        if (controller.isGrounded)
        {
            verticalSpeed = 0f;
            moveDir.y = verticalSpeed;
            moveDir = RequestMovimentGrounded(moveDir);
        } 
        else if(enableGravity)
        {
            verticalSpeed += gravity * Time.deltaTime;            
            moveDir.y = verticalSpeed;        
            moveDir = RequestMovimentNotGrounded(moveDir);
        }

        controller.Move(moveDir * Time.deltaTime);
    }

    public virtual Vector3 RequestMovimentGrounded(Vector3 moveDir){
        return moveDir;
    }
    public virtual Vector3 RequestMovimentNotGrounded(Vector3 moveDir){
        return moveDir;
    }
}
