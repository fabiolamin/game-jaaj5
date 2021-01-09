using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HawkController : Enemy
{

    [SerializeField] Transform HawkTransform;

    bool isFollowing;
    GameObject target;

    private void FixedUpdate()
    {
        if (isFollowing)
        {
            Move();
        }

    }

    void Move()
    {
        CheckDirection();
        Vector3 newPos = target.transform.position + new Vector3(0, 0.45f, 0);
        HawkTransform.position = Vector3.MoveTowards(HawkTransform.position, newPos, Time.deltaTime * movimentSpeed);
    }

    void CheckDirection()
    {
        if (target.transform.position.x > HawkTransform.position.x && HawkTransform.localScale.x < 0) // player is on the right
        {
            HawkTransform.localScale = new Vector2(HawkTransform.localScale.x * -1,HawkTransform.localScale.y);
        }
        else if (target.transform.position.x < HawkTransform.position.x && HawkTransform.localScale.x > 0)  // player is on the left
        {
            HawkTransform.localScale = new Vector2(HawkTransform.localScale.x * -1, HawkTransform.localScale.y);
        }
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
