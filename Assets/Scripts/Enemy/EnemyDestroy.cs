using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour, ITarget
{
    [SerializeField] AudioSource dieAudio;
    LootGenerator LootGen;

    public GameObject particle;

    private void Start()
    {
        LootGen = GetComponent<LootGenerator>();
    }
    public void Destroy()
    {
        dieAudio.PlayDelayed(0.12f);
        //Instantiate(particle, transform.position, Quaternion.identity);
        LootGen.Generate();
        gameObject.SetActive(false);
    }

   
}
