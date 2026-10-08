using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private CharacterController controller;
   [SerializeField] private Vector3 moveDirection;

    [Header("Movement Settings")]
    [Tooltip("ความเร็วในการวิ่งไปข้างหน้า")]
    public float forwardSpeed = 10f;
    [Tooltip("ความเร็วในการเคลื่อนที่หลบซ้าย-ขวา")]
    public float sidewaysSpeed = 8f;
    [Tooltip("ระยะห่างระหว่างแต่ละเลน (ถ้าใช้ระบบเปลี่ยนเลน)")]
    public float laneDistance = 2.5f; 
    private int targetLane = 1; // 0 = ซ้าย, 1 = ตรงกลาง, 2 = ขวา

    [Header("Jump & Gravity Settings")]
    [Tooltip("ความแรงในการกระโดด")]
    public float jumpHeight = 2f;
    [Tooltip("ค่าแรงโน้มถ่วง")]
    public float gravity = -20f;
    private float verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 1. วิ่งไปข้างหน้าอัตโนมัติ
        moveDirection.z = forwardSpeed;

        // 2. ควบคุมการหลบซ้าย / ขวา (รองรับทั้งปุ่ม A/D, Arrow Keys หรือระบบเลน)
        HandleLaneInput();

        // คำนวณตำแหน่งเป้าหมายในแนวแกน X
        float targetX = (targetLane - 1) * laneDistance;
        float currentX = Mathf.Lerp(transform.position.x, targetX, sidewaysSpeed * Time.deltaTime);
        moveDirection.x = (currentX - transform.position.x) / Time.deltaTime;

        // 3. จัดการเรื่องกระโดดและแรงโน้มถ่วง
        if (controller.isGrounded)
        {
            verticalVelocity = -2f; // กดตัวละครติดพื้นเล็กน้อยเวลาอยู่บนพื้น

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        else
        {
            // ถ้าอยู่กลางอากาศ ให้เพิ่มแรงโน้มถ่วงดึงลงมา
            verticalVelocity += gravity * Time.deltaTime;
        }

        moveDirection.y = verticalVelocity;

        // 4. เคลื่อนที่ตัวละครจริงผ่าน Character Controller
        controller.Move(moveDirection * Time.deltaTime);
    }

    void HandleLaneInput()
    {
        // กดซ้าย (A หรือ ลูกศรซ้าย)
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetLane--;
            targetLane = Mathf.Clamp(targetLane, 0, 2); // จำกัดให้อยู่แค่เลน 0, 1, 2
        }

        // กดขวา (D หรือ ลูกศรขวา)
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetLane++;
            targetLane = Mathf.Clamp(targetLane, 0, 2); // จำกัดให้อยู่แค่เลน 0, 1, 2
        }
    }
}
