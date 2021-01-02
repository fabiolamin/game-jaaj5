using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootGenerator : MonoBehaviour
{
   // public bool StartOn;
    public bool On;

    [SerializeField] int lootNum;
    [SerializeField] GameObject lootPrefab;

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
            if (lootNum == 1)
            {
                /*GameObject lootObj =*/
                Instantiate(lootPrefab, transform.position, Quaternion.identity);
                //  lootObj.AddForce

            }
            else if (lootNum > 1)
            {
                StartCoroutine(GenerateMultLoot());
            }
        }
        
    }

    IEnumerator GenerateMultLoot() 
    {
        for (int i = 0; i < lootNum; i++)
        {
            Instantiate(lootPrefab, transform.position, Quaternion.identity);
            yield return null;
        }
       
    }
}
