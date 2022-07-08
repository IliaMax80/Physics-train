using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RunGame : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("NST", 0);
        PlayerPrefs.SetInt("hints", 0);
        PlayerPrefs.SetInt("Coin", 0);
        PlayerPrefs.SetInt("Training", 0);
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
}
