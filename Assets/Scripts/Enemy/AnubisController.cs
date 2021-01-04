using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisController : Enemy
{
    // Public Variables
    public bool isMoving;

    // Private Variables
    [SerializeField] Transform minPos, maxPos;
    [SerializeField] Rigidbody2D anubisRb;
    [SerializeField] Transform anubisTransform;

    [SerializeField] Animator anubisAnim;

    int direction = 1; // -1 to move left and 1 to move right


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


    // Private Functios
    void Move(int direction) // -1 to move left and 1 to move right
    {
        anubisRb.velocity = new Vector2(Time.deltaTime * movimentSpeed * direction, anubisRb.velocity.y);
    }

    void DirectionCheck()
    {
        if (anubisTransform.position.x >= maxPos.position.x)
        {

            if (anubisRb.velocity.x > 0) // is moving to right
            {
                direction = -1; // turn to left
                anubisTransform.localScale = new Vector2(anubisTransform.localScale.x * -1, anubisTransform.localScale.y);
            }

        }
        else if (anubisTransform.position.x <= minPos.position.x)
        {
            if (anubisRb.velocity.x < 0) // is moving to left
            {
                direction = 1; // turn to right
                anubisTransform.localScale = new Vector2(anubisTransform.localScale.x * -1, anubisTransform.localScale.y);
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

    public override void Attack(Character character)
    {
        isMoving = false;
        StartCoroutine(StartAnimAttack());
    }

    IEnumerator StartAnimAttack()
    {
        anubisAnim.SetBool("attack", true);
        yield return new WaitForSeconds(0.5f);
        anubisAnim.SetBool("attack", false);
        isMoving = true;
    }


    public override void ChangeDirectionRaycast()
    {
        raycastHit = Physics2D.Raycast(rayOrigin.position, Vector3.right * direction, RayRange, layerChangeDirection);

        if (raycastHit.collider)
        {

            if (raycastHit.collider.CompareTag("Terrestrial"))
            {              
                direction *= -1;
                anubisTransform.localScale = new Vector2(anubisTransform.localScale.x * -1, anubisTransform.localScale.y);
            }

        }
    }

}
