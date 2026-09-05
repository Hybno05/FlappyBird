using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public InputActionReference moveAction;
    public InputActionReference jumpAction;
    public float movementSpeed = 10f;
    public float jumpSpeed = 10f;
    public bool is2D;

    private Vector2 _movement; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _movement = moveAction.action.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (is2D)
        {
            case false:
                gameObject.transform.position = new Vector2(_movement.x * movementSpeed, _movement.y * movementSpeed);
                break;
            case true:
                if (jumpAction.action.WasPerformedThisFrame())
                {
                    Jump();
                }
                gameObject.transform.position = new Vector2(_movement.x * movementSpeed, transform.position.y);
                break;
            default:
                break;
        }
    }

    void ChangeMode()
    {
        is2D = !is2D;
    }
    
    void Jump()
    {
        rb.linearVelocity = Vector2.up * jumpSpeed;
    }
}
