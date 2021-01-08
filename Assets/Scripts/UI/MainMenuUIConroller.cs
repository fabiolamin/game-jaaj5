using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUIConroller : MonoBehaviour
{
    [SerializeField]
    GameObject CreditsUI, MenuUi;

    [SerializeField]
    int indexOfLevelOne;

    private void Start()
    {
        CreditsUI.SetActive(false);
        MenuUi.SetActive(true);
    }
    public void Play()
    {
        SceneManager.LoadScene(indexOfLevelOne);
    }

    public void Credits()
    {
        MenuUi.SetActive(false);
        CreditsUI.SetActive(true);   
    }

    public void Return()
    {
        CreditsUI.SetActive(false);
        MenuUi.SetActive(true);  
    }
}
