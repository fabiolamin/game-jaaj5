using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarabController : Enemy
{
    // Public Variables
    public bool isMoving;

    // Private Variables
    [SerializeField] Transform minPos, maxPos;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform scarabTransform;

    int direction = 1; // -1 to move left and 1 to move right

 
    private void FixedUpdate()
    {

        if (isMoving)
        {
            Move(direction);
            DirectionCheck();
            ChangeDirectionRaycast();
        }


    }


    // Private Functios
    void Move(int direction) // -1 to move left and 1 to move right
    {
        rb.velocity = new Vector2(Time.deltaTime * movimentSpeed * direction, rb.velocity.y);
    }

    void DirectionCheck()
    {
        if (scarabTransform.position.x >= maxPos.position.x)
        {

            if (rb.velocity.x > 0) // is moving to right
            {
                direction = -1; // turn to left
                scarabTransform.localScale = new Vector2(scarabTransform.localScale.x * -1, scarabTransform.localScale.y);
            }

        }
        else if (scarabTransform.position.x <= minPos.position.x)
        {
            if (rb.velocity.x < 0) // is moving to left
            {
                direction = 1; // turn to right
                scarabTransform.localScale = new Vector2(scarabTransform.localScale.x * -1, scarabTransform.localScale.y);
            }

        }
    }


    public override void ChangeDirectionRaycast()
    {
        raycastHit = Physics2D.Raycast(rayOrigin.position, Vector3.right * direction, RayRange, layerChangeDirection);

        if (raycastHit.collider)
        {

            if (raycastHit.collider.CompareTag("Terrestrial"))
            {
                direction *= -1;
                scarabTransform.localScale = new Vector2(scarabTransform.localScale.x * -1, scarabTransform.localScale.y);
            }

        }
    }
}
