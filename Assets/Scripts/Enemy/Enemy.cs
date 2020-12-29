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
        actualLive = lives;
    }
    // Private Functions

    protected virtual void Attack(Character character) // need a player to attack
    {
       // character.Hit(1);
    }
}
