using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Private variables

    //public LootGenerator LootGen;  
    [SerializeField] protected float movimentSpeed;
    [SerializeField] protected int powerAttack;

    private void Start()
    {
       
    }
    // Private Functions
    protected virtual void Die() 
    {
        alive = false;
    }

    protected virtual void Attack(/*playerController player*/) // need a player to attack
    {
     // player.hit(hit);
    }
}
