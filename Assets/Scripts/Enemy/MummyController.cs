using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyController : Enemy
{
    // Public Variables
    public bool isMoving;

    // Private Variables
    [SerializeField] Transform minPos, maxPos;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform mummyTransform;
    [SerializeField] float reviveCooldown;
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
        if (mummyTransform.position.x >= maxPos.position.x)
        {

            if (rb.velocity.x > 0) // is moving to right
            {
                direction = -1; // turn to left
                mummyTransform.localScale = new Vector2(mummyTransform.localScale.x * -1, mummyTransform.localScale.y);
            }

        }
        else if (mummyTransform.position.x <= minPos.position.x)
        {
            if (rb.velocity.x < 0) // is moving to left
            {
                direction = 1; // turn to right
                mummyTransform.localScale = new Vector2(mummyTransform.localScale.x * -1, mummyTransform.localScale.y);
            }

        }
    }

    /* IEnumerator Revive()
     {
         yield return new WaitForSeconds(reviveCooldown);
         actualLive = lives;
         alive = true;
     }*/

    public override void ChangeDirectionRaycast()
    {
        raycastHit = Physics2D.Raycast(rayOrigin.position, Vector3.right * direction, RayRange, layerChangeDirection);

        if (raycastHit.collider)
        {

            if (raycastHit.collider.CompareTag("Terrestrial"))
            {
                direction *= -1;
                mummyTransform.localScale = new Vector2(mummyTransform.localScale.x * -1, mummyTransform.localScale.y);
            }

        }
    }
}
