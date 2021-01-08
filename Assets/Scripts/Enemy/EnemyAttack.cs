using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;

 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
           
            enemy.Attack(enemy.powerAttack);
        }
    }
}
