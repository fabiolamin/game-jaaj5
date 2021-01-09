using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;
    [SerializeField] float attackDelay;
    float canAttack = 0;

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Attack();
        }
    }

    void Attack()
    {
        if (Time.time > canAttack)
        {
            canAttack = Time.time + attackDelay;
            enemy.Attack(enemy.powerAttack);
        }
       
    }
}
