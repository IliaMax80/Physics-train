using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UpdateText : MonoBehaviour
{   
    [SerializeField] private TransformerCore Core;
    public bool n1, n2;
    [SerializeField] private Text text;
    private string txt; 
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(n1)
        {
            txt = Core.n1.ToString();
        }
        else if(n2)
        {
            txt = Core.n2.ToString();
        } 
        text.text = txt; 
        //SceneManager и сверху класс вызова
        //PlayerPrefs - Сохранения данных
    }
}
