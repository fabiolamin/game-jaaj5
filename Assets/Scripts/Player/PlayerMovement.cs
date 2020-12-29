using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Collider2D playerCollider;
    private Vector2 movement = Vector2.zero;
    private float horizontalInput;
    private int scaleX = 1;
    private bool canJump = false;
    private float initialHeight = 0;

    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float jumpVelocity = 50f;
    [SerializeField] private float maxHeight = 10f;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        GetPlayerInput();
        Rotate();
        Move();
    }

    private void GetPlayerInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
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

    private void Move()
    {
        movement = playerRb.velocity;
        movement.x = horizontalInput * movementSpeed;
        CheckJump();
        playerRb.velocity = movement;
    }

    private void CheckJump()
    {
        if (IsOnTheGround() && Input.GetKeyDown(KeyCode.Space))
        {
            SetJump();
        }

        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            ControlJump();
        }
    }

    private bool IsOnTheGround()
    {
        return Physics2D.IsTouchingLayers(playerCollider, LayerMask.GetMask("Ground"));
    }

    private void SetJump()
    {
        initialHeight = transform.position.y;
        movement.y = jumpVelocity;
        canJump = true;
    }

    private void ControlJump()
    {
        if (transform.position.y <= initialHeight + maxHeight)
        {
            movement.y = jumpVelocity;
        }
        else
        {
            canJump = false;
        }
    }
}
