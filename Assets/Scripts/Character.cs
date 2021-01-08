using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, ITarget
{
     
    public void Destroy()
    {
        //Instantiate(particle, transform.position, Quaternion.identity);
        //LootGen.Generate();
        gameObject.SetActive(false);
    }
}
