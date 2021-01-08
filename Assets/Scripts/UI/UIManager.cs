using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject FinishGameUI, PauseGameUI;

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
    }

    public static void FinishLevel(int level)
    {
        UIManager.instance.FinishGameUI.SetActive(false);
    }


}
