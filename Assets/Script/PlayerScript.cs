using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public InputActionReference moveAction;
    public InputActionReference jumpAction;
    public InputActionReference changemodeAction;
    public float movementSpeed = 10f;
    public float jumpSpeed = 5f;
    public bool is2D;

    private Vector2 _movement; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _movement = moveAction.action.ReadValue<Vector2>();
        if (changemodeAction.action.WasPressedThisFrame())
        {
            ChangeMode();
        }

        switch (is2D)
        {
            case false:
                rb.gravityScale = 0;
                gameObject.transform.position += new Vector3(_movement.x * movementSpeed * Time.deltaTime, _movement.y * movementSpeed * Time.deltaTime, 0);
                break;
            case true:
                rb.gravityScale = 1f;
                if (jumpAction.action.WasPerformedThisFrame())
                {
                    Jump();
                }
                gameObject.transform.position += new Vector3(_movement.x * movementSpeed * Time.deltaTime, 0,0);
                break;
        }
    }

    void ChangeMode()
    {
        is2D = !is2D;
    }
    
    void Jump()
    {
        rb.linearVelocity = Vector2.up* jumpSpeed;
    }
}
