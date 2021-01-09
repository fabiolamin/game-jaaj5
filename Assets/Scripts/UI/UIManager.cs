using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject FinishGameUI, PauseGameUI, GamePlayUI;

    public Text playerPontuation;

    int _nextLevel;

    private static UIManager _instace;
    public static UIManager instance
    {
        get
        {
            if (_instace == null)
            {
                _instace = FindObjectOfType<UIManager>();
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            PauseButton();
        }
    }

    public void FinishLevel(int level)
    {       
        _nextLevel = level;
        GamePlayUI.SetActive(false);
        FinishGameUI.SetActive(true);
        playerPontuation.text = PlayerManager.Instance.PlayerScore.Score.ToString();
        Time.timeScale = 0;
    }

    public void ContinueButton()
    {
        Time.timeScale = 1;
        PauseGameUI.SetActive(false);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void PauseButton()
    {
        PauseGameUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void NextLevelButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_nextLevel);
    }

    public void MenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
