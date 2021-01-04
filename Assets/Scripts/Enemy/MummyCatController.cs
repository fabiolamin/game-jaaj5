using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyCatController : Enemy
{
    public bool MovingOnAweke;
    public bool isMoving;
    public float tempToStop, tempToMove;

    // Private Variables
    [SerializeField] Transform minPos, maxPos;
    [SerializeField] Rigidbody2D catRb;
    [SerializeField] Transform catTransform;
    int direction = 1; // -1 to move left and 1 to move right
    float time; // for delay calculations

    private void Start()
    {
        if (MovingOnAweke) 
        {
            StartCoroutine(MoveState());
        }
        else 
        {
            StartCoroutine(StopState());
        }
        
    }
    private void FixedUpdate()
    {

        if (alive)
        {

            if (isMoving)
            {
                Move(direction);
                DirectionCheck();
                ChangeDirectionRaycast();

            }

        }


    }

    IEnumerator MoveState() // When the enemy is moving on
    {
        isMoving = true;
        yield return new WaitForSeconds(tempToStop);
        StartCoroutine(StopState());
    }

    IEnumerator StopState() // When the enemy is stopped
    {
        isMoving = false;
        yield return new WaitForSeconds(tempToMove);
        StartCoroutine(MoveState());
       
    }




    // Private Functios
    void Move(int direction) // -1 to move left and 1 to move right
    {
        catRb.velocity = new Vector2(Time.deltaTime * movimentSpeed * direction, catRb.velocity.y);
    }

    void DirectionCheck() // Change the direction and scale x
    {
        if (catTransform.position.x >= maxPos.position.x)
        {

            if (catRb.velocity.x > 0) // is moving to right
            {
                direction = -1; // turn to left
                catTransform.localScale = new Vector2(catTransform.localScale.x * -1, catTransform.localScale.y);
            }

        }
        else if (catTransform.position.x <= minPos.position.x)
        {
            if (catRb.velocity.x < 0) // is moving to left
            {
                direction = 1; // turn to right
                catTransform.localScale = new Vector2(catTransform.localScale.x * -1, catTransform.localScale.y);
            }

        }
    }

    protected override void Die()
    {
        alive = false;
        //anim die
    }
    protected override void Hit(int damage)
    {
        base.Hit(damage);
    }

    public override void ChangeDirectionRaycast()
    {
        raycastHit = Physics2D.Raycast(rayOrigin.position, Vector3.right * direction, RayRange, layerChangeDirection);

        if (raycastHit.collider)
        {

            if (raycastHit.collider.CompareTag("Terrestrial"))
            {
                direction *= -1;
                catTransform.localScale = new Vector2(catTransform.localScale.x * -1, catTransform.localScale.y);
            }

        }
    }

}
