using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public LootGenerator LootGen;
    public GameObject particle;
    public Transform particlePos;

    [SerializeField] public bool alive;
    [SerializeField] protected int lives, actualLive;
    // Start is called before the first frame update
    void Start()
    {
        actualLive = lives;
    }

    public virtual void Hit(int damage)
    {
        actualLive -= damage;

        if (actualLive <= 0) 
        {
            actualLive = 0;           
            Die();
        }
    }

    protected virtual void Die()
    {
        alive = false;
        LootGen.Generate();
        //Instantiate(particle, particlePos.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
