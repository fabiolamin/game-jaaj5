using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour, ITarget
{
    [SerializeField] AudioSource dieAudio;
    [SerializeField] private ParticleSystem enemyDeathParticles;
    LootGenerator LootGen;

    private void Start()
    {
        LootGen = GetComponent<LootGenerator>();
    }
    public void Destroy()
    {
        dieAudio.PlayDelayed(0.12f);
        Instantiate(enemyDeathParticles, transform.position, Quaternion.identity);
        LootGen.Generate();
        gameObject.SetActive(false);
    }

   
}
