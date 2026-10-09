using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private CharacterController controller;
   [SerializeField] private Vector3 moveDirection;

    [Header("Movement Settings")]
    
    public float forwardSpeed = 10f;
   
    public float sidewaysSpeed = 8f;
    
    public float laneDistance = 2.5f; 
    private int targetLane = 1; // 0 = ซ้าย, 1 = ตรงกลาง, 2 = ขวา

    [Header("Jump & Gravity Settings")]
   
    public float jumpHeight = 2f;
    
    public float gravity = -20f;
    private float verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
       
        moveDirection.z = forwardSpeed;

       
        HandleLaneInput();

       
        float targetX = (targetLane - 1) * laneDistance;
        float currentX = Mathf.Lerp(transform.position.x, targetX, sidewaysSpeed * Time.deltaTime);
        moveDirection.x = (currentX - transform.position.x) / Time.deltaTime;

      
        if (controller.isGrounded)
        {
            verticalVelocity = -2f; 

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        else
        {
         
            verticalVelocity += gravity * Time.deltaTime;
        }

        moveDirection.y = verticalVelocity;

        
        controller.Move(moveDirection * Time.deltaTime);
    }

    void HandleLaneInput()
    {
      
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetLane--;
            targetLane = Mathf.Clamp(targetLane, 0, 2); 
        }

      
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetLane++;
            targetLane = Mathf.Clamp(targetLane, 0, 2);
        }
    }
}
