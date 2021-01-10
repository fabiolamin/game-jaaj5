using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevelTrigger : MonoBehaviour
{
    public int nextLevelIndex;
    [SerializeField] AudioSource winAudio, gameplayAudio;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            gameplayAudio.Stop();
            winAudio.Play();
            UIManager.instance.FinishLevel(nextLevelIndex);
        }

    }
}
