using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private float horizontalInput;
    private float jumpInput;
    private int scaleX = 1;
    private bool isOnTheGround = true;
    private Vector2 movement = Vector2.zero;

    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float jumpForce = 55f;
    [SerializeField] private float defaultGravityScale = 50f;
    [SerializeField] private float gravityIncrement = 1f;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckIfPlayerIsOnTheGround();
        GetPlayerInput();
        Rotate();
    }

    private void CheckIfPlayerIsOnTheGround()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.8f, LayerMask.GetMask("Ground")))
        {
            playerRb.gravityScale = defaultGravityScale;
            isOnTheGround = true;
        }
        else
        {
            playerRb.gravityScale += gravityIncrement;
            isOnTheGround = false;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetPlayerInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Jump");
    }

    private void Move()
    {
        movement = new Vector2(horizontalInput * movementSpeed, GetJumpValue() * jumpForce);
        playerRb.velocity = movement;
    }

    private void Rotate()
    {
        if (horizontalInput > 0) { scaleX = 1; }
        else if (horizontalInput < 0) { scaleX = -1; }

        transform.localScale = new Vector3(
        scaleX,
        transform.localScale.y,
        transform.localScale.z);
    }

    private float GetJumpValue()
    {
        if(isOnTheGround && jumpInput == 1f)
        {
            return 0;
        };

        return jumpInput;
    }
}
