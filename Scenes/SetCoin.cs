using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetCoin : MonoBehaviour
{
    public bool coin;
    // Start is called before the first frame update
    void Start()
    {
        if (coin)
        {
            if (GetComponent<Text>() & PlayerPrefs.HasKey("Coin"))
            {
                GetComponent<Text>().text = PlayerPrefs.GetInt("Coin").ToString();
            }
        }
        else
        {
            if (GetComponent<Text>() & PlayerPrefs.HasKey("NST"))
            {
                GetComponent<Text>().text = PlayerPrefs.GetInt("NST").ToString();
            }
        }


    }
}
