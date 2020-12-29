using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBallController : Enemy
{
   
    [SerializeField] Transform sandBallTransform;

    bool isFollowing;
    GameObject target;


    private void FixedUpdate()
    {
        if (alive)
        {
            if(isFollowing)
            {
                Move();
            }
        }
        
    }

    void Move() // -1 to move left and 1 to move right
    {
        sandBallTransform.position = Vector3.MoveTowards(sandBallTransform.position, target.transform.position, Time.deltaTime * movimentSpeed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            target = col.gameObject;
            isFollowing = true;
        }
    }
}
