using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Private variables

    public LootGenerator LootGen;
   
    [SerializeField] protected float movimentSpeed;
    [SerializeField] protected int powerAttack;

    [SerializeField] protected LayerMask layerChangeDirection;
    [SerializeField] protected Transform rayOrigin;
    [SerializeField] protected float RayRange;


    protected  RaycastHit2D raycastHit;

    private void Start()
    {
        actualLive = lives;
    }
    // Private Functions

    public virtual void Attack(Character character) // need a player to attack
    {
        // character.Hit(1);
    }

    public virtual void ChangeDirectionRaycast() 
    {
       //
    }
}
