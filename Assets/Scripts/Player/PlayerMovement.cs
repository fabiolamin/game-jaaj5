using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Vector2 movement = Vector2.zero;
    private float horizontalInput;
    private int scaleX = 1;
    private bool canJump = false;
    private float initialHeight = 0;

    [SerializeField] private Collider2D footCollider;
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float jumpVelocity = 50f;
    [SerializeField] private float maxHeight = 10f;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
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

        if(Input.GetKeyUp(KeyCode.Space) && canJump)
        {
            canJump = false;
        }
    }

    private bool IsOnTheGround()
    {
        return Physics2D.IsTouchingLayers(footCollider, LayerMask.GetMask("Ground"));
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
