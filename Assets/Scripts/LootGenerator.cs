using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootGenerator : MonoBehaviour
{
   // public bool StartOn;
    public bool On;
    [SerializeField] bool RandomLoot;
    [SerializeField] int MinDropNum, MaxDropNum;
    [SerializeField] GameObject[] lootPrefab;

    private void Start()
    {
      /*if (StartOn) 
        {
            On = true;
        }
        */
    }
   

    public void Generate() 
    {
        if (On) 
        {
            if (lootPrefab.Length == 1)
            {           
                Instantiate(lootPrefab[0], transform.position, Quaternion.identity);  
            }
            else if (lootPrefab.Length > 1)
            {
                StartCoroutine(GenerateMultLoot());
            }
        }
        
    }

    IEnumerator GenerateMultLoot() 
    {
        if (RandomLoot) 
        {
          int  X = Random.Range(MinDropNum, MaxDropNum + 1);

            for (int i = 0; i < X; i++)
            {
                Instantiate(lootPrefab[Random.Range(0,lootPrefab.Length)], transform.position, Quaternion.identity);
            }
            
        }
        else 
        {
            for (int i = 0; i < lootPrefab.Length; i++)
            {
                Instantiate(lootPrefab[i], transform.position, Quaternion.identity);
                yield return null;
            }
        }
       
       
    }
}
