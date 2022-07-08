using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class RunTask : MonoBehaviour
{

    [SerializeField] Text text;
    private bool hints;
    public void Start()
    {
        if (PlayerPrefs.GetInt("NST") == 0)
        {
            SetHints(true);
        }
        else
        {
            SetHints(false);
        }
        PlayerPrefs.SetInt("Training", 0);
    }
    public void Run()
    {
        SceneManager.LoadScene(2);
    }
    public void SetHints(bool a)
    {
        hints = a;
        if (a)
        {
            PlayerPrefs.SetInt("hints", 1);
            text.text = "Включено";
        }
        else
        {
            PlayerPrefs.SetInt("hints", 0);
            text.text = "Выключено";
        }
    }
    public void SetTraining()
    {
        PlayerPrefs.SetInt("Training", 1);
    }
    public void NextHints()
    {
        SetHints(!hints);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
