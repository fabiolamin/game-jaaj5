using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackCollider : MonoBehaviour
{
    public Enemy enemy;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) 
        {
            enemy.Attack(col.gameObject.GetComponent<Character>());
        }
    }
}
