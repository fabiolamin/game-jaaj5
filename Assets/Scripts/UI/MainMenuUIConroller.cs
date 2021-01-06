using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUIConroller : MonoBehaviour
{
    [SerializeField]
    Button playButton, creditsButton, returnButton;

    [SerializeField]
    GameObject creditsUi;

    public void Play(int _scene)
    {
        SceneManager.LoadScene(_scene);
    }

    public void Credits()
    {

    }

    public void Return()
    {

    }
}
