using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Private variables

    //public LootGenerator LootGen;
    [SerializeField] protected int lives;
    [SerializeField] protected float movimentSpeed;
    [SerializeField] protected int powerAttack;

    // Private Functions
    void Die() 
    {
    
    }

    void Attack(/*playerController player*/) // need a player to attack
    {
    
    }
}
