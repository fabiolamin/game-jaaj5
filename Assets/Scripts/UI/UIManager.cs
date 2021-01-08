using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject FinishGameUI, PauseGameUI, GamePlayUI;

    private static UIManager _instace;
    public static UIManager instance
    {
        get
        {
            if(_instace == null) 
            {
               _instace = GameObject.FindObjectOfType<UIManager>();
            }
            return _instace;
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        FinishGameUI.SetActive(false);
        PauseGameUI.SetActive(false);
        GamePlayUI.SetActive(true);
    }

    public static void FinishLevel(int level)
    {
        UIManager.instance.FinishGameUI.SetActive(false);
    }

    public void ContinueButton() 
    {
    
    }
    public void RestartButton()
    {

    }

    public void PauseButton()
    {

    }

    public void NextLevelButton()
    {

    }

    public void MenuButton()
    {

    }
}
