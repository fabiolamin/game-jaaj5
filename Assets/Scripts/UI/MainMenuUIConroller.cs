using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUIConroller : MonoBehaviour
{
    [SerializeField]
    GameObject CreditsUI, MenuUi, TutorialUI;

    [SerializeField]
    int indexOfLevelOne;

    private void Start()
    {
        CreditsUI.SetActive(false);
        TutorialUI.SetActive(false);
        MenuUi.SetActive(true);
    }
    public void Play()
    {
        SceneManager.LoadScene(indexOfLevelOne);
    }

    public void Tutorial() 
    {
        MenuUi.SetActive(false);
        TutorialUI.SetActive(true);
    }
    public void Credits()
    {
        MenuUi.SetActive(false);
        CreditsUI.SetActive(true);   
    }

    public void Return()
    {
        CreditsUI.SetActive(false);
        TutorialUI.SetActive(false);
        MenuUi.SetActive(true);  
    }

    public void Quit()
    {
        Application.Quit();
    }
}
