using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpavnOperator : MonoBehaviour
{

    public string operatorStr;
    public int operation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spavn(GameObject a)
    {
        a.GetComponent<OperatorScript>().txt.text = operatorStr;
        a.GetComponent<OperatorScript>().OperatorNumber = operation;
        if (operation == 5)
        {
            a.GetComponent<ScalingTablet>().Start();
            a.GetComponent<OperatorScript>().SetRLP();
        }
    }

}
