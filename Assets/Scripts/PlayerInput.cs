using System;
using Mono.Cecil;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public float movementSpeed = 10f;
    public float jumpSpeed = 10f;
    public InputActionReference move;
    public InputActionReference jump;
    public InputActionReference switch2D;
    public LogicScript logic;
    public bool alive = true;
    public bool is2D = false;
    
    private Vector2 _movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (is2D && alive)
        {
            _movement = move.action.ReadValue<Vector2>();
            playerRigidbody.linearVelocity = new Vector2(_movement.x * movementSpeed, _movement.y * movementSpeed);
            if (jump.action.WasPressedThisFrame())
            {
                Jump();
            }
        }
        else if(jump.action.WasPressedThisFrame() && alive && !is2D)
        {
            Jump();
        }

        if (switch2D.action.WasPressedThisFrame())
        {
            ChangeGravity();
        }
    }

    private void ChangeGravity()
    {
        is2D = !is2D;
        if (is2D)
        {
            playerRigidbody.gravityScale = 0;
        }
        else
        {
            playerRigidbody.gravityScale = 2.5f;
        }
    }

    public void Jump()
    {
        playerRigidbody.linearVelocity = Vector2.up * jumpSpeed;
    }

    /*private void OnEnable()
    {
            jump.action.started += Jump;
    }


    private void OnDisable()
    {

        jump.action.started -= Jump;
    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        if (alive)
        {
            playerRigidbody.linearVelocity = Vector2.up * jumpSpeed;
        }
    }*/

    private void OnCollisionEnter2D(Collision2D other)
    {
        logic.gameOver();
        alive = false;
    }
}
