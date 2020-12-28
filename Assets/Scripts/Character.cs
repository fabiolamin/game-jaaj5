using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected bool alive;
    [SerializeField] protected int lives, actualLive;
    // Start is called before the first frame update
    void Start()
    {
        actualLive = lives;
    }

    protected virtual void Hit(int damage)
    {
        actualLive -= damage;
    }

    protected virtual void Die()
    {
        //
    }

}
