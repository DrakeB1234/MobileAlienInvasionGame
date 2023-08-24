using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D rb;
    [SerializeField] 
    private Animator characterAnimator;
    [SerializeField] 
    private UIController uiController;
    public float speed;
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

    public float distance;

    private void Awake() 
    {
        jumpHoldTimer = jumpHoldTime;   

        Application.targetFrameRate = 60; 
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

        if (rb.velocity.y == 0)
        {
            // Set bool for jump animation
            characterAnimator.SetBool("isJumping", false);
        }

        // Updates public distance variable by speed, call function to update UI
        distance += speed * Time.deltaTime;
        uiController.UpdateDistance(distance);
    }

    public void PlayerJump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            jumpHold = true;

            // Set bool for jump animation
            characterAnimator.SetBool("isJumping", true);
            // Trigger jump animation
            characterAnimator.SetTrigger("Jump");

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
        return Physics2D.OverlapCircle(groundPos.position, 0.2f, groundLayer);
    }
}
