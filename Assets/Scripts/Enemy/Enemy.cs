using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Private variables

    //public LootGenerator LootGen;
    [SerializeField] int lives;
    [SerializeField] float movimentSpeed;
    [SerializeField] int powerAttack;

    // Private Functions
    void Die() 
    {
    
    }

    void Attack(/*playerController player*/) // need a player to attack
    {
    
    }
}
