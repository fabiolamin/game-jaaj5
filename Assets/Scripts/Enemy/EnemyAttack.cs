using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
   
    Enemy enemy;

    private void Start()
    {
        enemy = transform.root.GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player") 
        {
            if (enemy.alive)
                enemy.Attack(enemy.powerAttack);
        }
    }
}
