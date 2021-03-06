using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement = Vector2.zero;
    private float horizontalInput;
    private bool hasTurned;
    private float forward = 1f;
    private bool isJumping = false;
    private float initialHeight = 0;

    [SerializeField] private Collider2D footCollider;
    [SerializeField] private Collider2D headCollider;
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float jumpVelocity = 50f;
    [SerializeField] private float maxJumpingHeight = 10f;

    public Vector2 ForwardDirection { get; private set; }

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        hasTurned = spriteRenderer.flipX;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Rotate();
        Move();
    }

    private void Rotate()
    {
        if (horizontalInput > 0)
        {
            hasTurned = false;
        }
        else if (horizontalInput < 0)
        {
            hasTurned = true;
        }

        spriteRenderer.flipX = hasTurned;

        SetForwardDirection();
    }

    private void SetForwardDirection()
    {
        if (horizontalInput != 0)
        {
            forward = Mathf.Sign(horizontalInput);
        }

        ForwardDirection = new Vector2(forward, 0);
    }

    private void Move()
    {
        movement = playerRb.velocity;
        movement.x = horizontalInput * movementSpeed;
        CheckJump();
        playerRb.velocity = movement;
        PlayerManager.Instance.PlayerAnimator.SetBool("IsMoving", horizontalInput != 0);
    }

    private void CheckJump()
    {
        if (IsOnTheGround() && Input.GetKeyDown(KeyCode.Space))
        {
            SetJump();
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            ControlJump();
        }

        if (Input.GetKeyUp(KeyCode.Space) || IsTouchingRoof())
        {
            isJumping = false;
        }

        PlayerManager.Instance.PlayerAnimator.SetBool("IsJumping", !IsOnTheGround());
    }

    public bool IsOnTheGround()
    {
        return Physics2D.IsTouchingLayers(footCollider);
    }

    private void SetJump()
    {
        initialHeight = transform.position.y;
        movement.y = jumpVelocity;
        isJumping = true;
        PlayerManager.Instance.PlayerAnimator.SetTrigger("Jump");
    }

    private void ControlJump()
    {
        if (transform.position.y <= initialHeight + maxJumpingHeight)
        {
            movement.y = jumpVelocity;
        }
        else
        {
            isJumping = false;
        }
    }

    public bool IsTouchingRoof()
    {
        return Physics2D.IsTouchingLayers(headCollider);
    }
}
