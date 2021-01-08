using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, ITarget
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

    public void Destroy()
    {
        //Instantiate(particle, particlePos.position, Quaternion.identity);
        LootGen.Generate();
        gameObject.SetActive(false);
    }
}
