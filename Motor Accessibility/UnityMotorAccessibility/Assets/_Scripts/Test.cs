using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI jumpText;
    [SerializeField]
    private TextMeshProUGUI movementText;

    private InputAction movement;
    private InputAction jump;

    //Check if player is pressing the jump key/button
    private void Jump()
    {
        if (jump.ReadValue<float>() == 1)
        {
            jumpText.text = "Jump!";
        }
        else
        {
            jumpText.text = "Player is not jumping";
        }
    }

    //Check if the player is pressing any of the movement buttons
    private void Movement()
    {
        if(movement.ReadValue<Vector2>().x != 0 || movement.ReadValue<Vector2>().y != 0)
        {
            movementText.text = "Player is moving ";
            if (movement.ReadValue<Vector2>().x > 0)
            {
                movementText.text += "right";
            }
            else if (movement.ReadValue<Vector2>().x < 0)
            {
                movementText.text += "left";
            }
            else if (movement.ReadValue<Vector2>().y > 0)
            {
                movementText.text += "up";
            }
            else
            {
                movementText.text += "down";
            }
        }
        else
        {
            movementText.text = "Player is not moving";
        }
    }

    //Check for any player input
    private void Update()
    {
        Jump();
        Movement();
    }

    //Set up all variables
    private void Awake()
    {
        PlayerInput playerInput = FindObjectOfType<PlayerInput>();
        jump = playerInput.actions["Jump"];
        movement = playerInput.actions["Movement"];
    }
}
