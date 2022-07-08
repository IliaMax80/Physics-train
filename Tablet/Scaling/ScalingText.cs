using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ScalingText : MonoBehaviour
{
    [SerializeField] private TextMesh text;
    private int len;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GetComponent<ScalingTablet>() & len != text.text.Length)
        {
            UpdateScaling();

        }
        if(text.text.Length == 0)
        {
            GetComponent<ScalingTablet>().length = 9;
            GetComponent<ScalingTablet>().UpdateSaze();
        }
        len = text.text.Length;

        //text.text.Length 
    }
    public void UpdateScaling()
    {
        GetComponent<ScalingTablet>().length = 1.05f + 2.65f * text.text.Length;
        GetComponent<ScalingTablet>().UpdateSaze();
    } 
}
