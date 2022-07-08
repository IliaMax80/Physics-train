using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberScript : MonoBehaviour
{
    [SerializeField] Text text;
    // Start is called before the first frame update
    public float values;
    private string buf;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ok()
    {
        float a;
        if(float.TryParse(text.text, out a))
        {
            GetComponent<spavnTablet>().updateValue(a);
            GetComponent<BoxCollider>().enabled = true;
        }

    }
}
