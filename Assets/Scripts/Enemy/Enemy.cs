using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Private variables
    public int powerAttack;

    [SerializeField] protected float movimentSpeed;
   

    [SerializeField] protected LayerMask layerChangeDirection;
    [SerializeField] protected Transform rayOrigin;
    [SerializeField] protected float RayRange;
   

    protected  RaycastHit2D raycastHit;

  
    // Private Functions

    public virtual void Attack(int damage) // need a player to attack
    {       
        PlayerManager.Instance.PlayerHealth.GetDamage();
    }

    public virtual void ChangeDirectionRaycast() 
    {
       //
    }
}
