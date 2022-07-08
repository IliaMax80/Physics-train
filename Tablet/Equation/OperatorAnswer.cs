using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorAnswer : MonoBehaviour
{
    public GameObject Operator;
    // Start is called before the first frame update
    public void Start()
    {
        GetComponent<spavnTablet>().max = Operator.GetComponent<Taskability>().Max;
        GetComponent<spavnTablet>().min = Operator.GetComponent<Taskability>().Min;
        GetComponent<spavnTablet>().Controller = Operator.GetComponent<Taskability>().Controller;
    }
    public void update()
    {
        if (Operator.GetComponent<OperatorScript>().ok)
        {
            GetComponent<spavnTablet>().updateValue(Operator.GetComponent<Taskability>().value);
            GetComponent<ScalingText>().UpdateScaling();
            GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            GetComponent<spavnTablet>().updateText("   ");
            GetComponent<ScalingText>().UpdateScaling();
            GetComponent<BoxCollider>().enabled = false;
        }
    } 
}
