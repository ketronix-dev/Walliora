using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings:")]
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float targetHeight = 0.3f;

    [Header("Materials:")]
    [SerializeField] private Material Red;
    [SerializeField] private Material Green;
    
    private CharacterController controller;

    void Start()
    {
        joystick = GameObject.FindWithTag("Joystick").GetComponent<Joystick>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 moveDirection = new Vector3(-joystick.Horizontal, 0, -joystick.Vertical);
        moveDirection *= speed;

        if (!controller.isGrounded)
        {
            moveDirection.y -= 9.81f * Time.deltaTime; // Apply gravity
        }
        else
        {
            moveDirection.y = 0; // Reset y velocity if grounded
        }

        // Keep player at target height
        float currentHeight = transform.position.y;
        float distanceToTargetHeight = targetHeight - currentHeight;
        moveDirection.y += distanceToTargetHeight;

        controller.Move(moveDirection * Time.deltaTime);
    }
}