using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevelTrigger : MonoBehaviour
{
    public int nextLevelIndex;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {         
            UIManager.instance.FinishLevel(nextLevelIndex);
        }

    }
}
