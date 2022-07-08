using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HintsScript : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        if (PlayerPrefs.HasKey("hints"))
        {
            if (PlayerPrefs.GetInt("hints") == 0)
            {
                delet();
            }
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (PlayerPrefs.HasKey("hents"))
    //    {
    //        if (PlayerPrefs.GetInt("hents") == 0)
    //        {
    //            delet();
    //        }
    //    }
    //}
    public void delet()
    {
        Destroy(gameObject);
    }
}
