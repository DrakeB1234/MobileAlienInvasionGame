using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D rb;
    [SerializeField] 
    private float speed;
    [SerializeField] 
    private float jumpForce;
    [SerializeField] 
    private float jumpHoldTime;
    [SerializeField] 
    private LayerMask groundLayer;
    [SerializeField] 
    private Transform groundPos;

    private bool jumpHold;
    private float jumpHoldTimer;

    private void Awake() 
    {
        jumpHoldTimer = jumpHoldTime;    
    }

    private void Update() 
    {
        if (jumpHold)
        {
            if (jumpHoldTimer > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpHoldTimer -= Time.deltaTime;
            }
            else 
            {
                jumpHold = false;
            }
        }    
    }

    public void PlayerJump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            jumpHold = true;

            // Resets jump timer for longer jumps
            jumpHoldTimer = jumpHoldTime;
        }

        if (context.canceled)
        {
            jumpHold = false;
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundPos.position, 0.1f, groundLayer);
    }
}
