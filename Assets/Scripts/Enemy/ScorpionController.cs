using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionController : Enemy
{
    // Public Variables
    public bool isMoving;
   
    // Private Variables
    [SerializeField] Transform minPos, maxPos;
    [SerializeField] float followSpeed;
    [SerializeField] Rigidbody2D scorpRb;
    [SerializeField] Transform scorpTransform;
    [SerializeField] Animator scorpAnim;


    int direction = 1; // -1 to move left and 1 to move right
    bool isFollowing;
    Transform target;

    private void FixedUpdate()
    {

        if (alive)
        {
            if (isMoving)
            {
                if (!isFollowing) 
                {
                    Move(direction);
                    DirectionCheck();
                    ChangeDirectionRaycast();
                }
                else 
                {
                    MoveToTarget(target);
                }             
               

            }

        }


    }

    public void FollowTarget(Transform _target) 
    {
        target = _target;
        isFollowing = true;
    }
    public void StopFollow() 
    {
        isFollowing = false;
        target = null;

        if (direction == -1 && scorpTransform.localScale.x > 0) 
        {
            scorpTransform.localScale = new Vector2(scorpTransform.localScale.x * -1, scorpTransform.localScale.y);
        }
        else if(direction == 1 && scorpTransform.localScale.x < 0)
        {
            scorpTransform.localScale = new Vector2(scorpTransform.localScale.x * -1, scorpTransform.localScale.y);
        }
    }

    // Private Functios

    void MoveToTarget(Transform _target) 
    {
        scorpTransform.position = Vector3.MoveTowards(scorpTransform.position, new Vector2(target.position.x,scorpTransform.position.y), followSpeed * Time.deltaTime);

        if (target.position.x > scorpTransform.position.x) 
        {
            scorpTransform.localScale = new Vector2(1, scorpTransform.localScale.y);
        }
        else 
        {
            scorpTransform.localScale = new Vector2(-1, scorpTransform.localScale.y);
        }
    }

    void Move(int direction) // -1 to move left and 1 to move right
    {
        scorpRb.velocity = new Vector2(Time.deltaTime * movimentSpeed * direction, scorpRb.velocity.y);
    }

    void DirectionCheck()
    {
        if (scorpTransform.position.x >= maxPos.position.x)
        {

            if (scorpRb.velocity.x > 0) // is moving to right
            {
                direction = -1; // turn to left
                scorpTransform.localScale = new Vector2(scorpTransform.localScale.x *-1, scorpTransform.localScale.y);
            }

        }
        else if (scorpTransform.position.x <= minPos.position.x)
        {
            if (scorpRb.velocity.x < 0) // is moving to left
            {
                direction = 1; // turn to right
                scorpTransform.localScale = new Vector2(scorpTransform.localScale.x * -1, scorpTransform.localScale.y);
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

    }

    public override void Attack(Character character)
    {

    }



    public override void ChangeDirectionRaycast()
    {
        raycastHit = Physics2D.Raycast(rayOrigin.position, Vector3.right * direction, RayRange, layerChangeDirection);

        if (raycastHit.collider)
        {

            if (raycastHit.collider.CompareTag("Terrestrial"))
            {
                direction *= -1;
                scorpTransform.localScale = new Vector2(scorpTransform.localScale.x * -1, scorpTransform.localScale.y);
            }

        }
    }

}
