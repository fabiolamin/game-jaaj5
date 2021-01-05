using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrondSensorScorpion : MonoBehaviour
{
    [SerializeField] ScorpionController scorpion;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) 
        {
            scorpion.FollowTarget(col.gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            scorpion.StopFollow();
        }
    }
}
