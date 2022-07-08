using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public List<GameObject> equation = new List<GameObject>();
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        updateAnswer();
    }
    public void add(GameObject a)
    {
        equation.Add(a);
        //updateAnswer();
    }
    public void delet(GameObject a)
    {
        List<GameObject> buf = new List<GameObject>();
        foreach(GameObject b in equation)
        {
            if(b != a)
            {
                buf.Add(b);
            }
        }
        equation = buf;
        //updateAnswer();

    }
    //public void off()
    //{
    //    foreach(GameObject b in equation)
    //    {
    //        b.GetComponent<OperatorScript>().ActiveOff();
    //    } 
    //}
    void updateAnswer()
    {
        bool b;
        GameObject buf;
        buf = null;
        foreach(GameObject a in equation)
        {
            if (a.GetComponent<OperatorScript>().active)
            {
                buf = a;
                break;
            }
        }
        if(buf != null)
        {
            if (buf.GetComponent<OperatorScript>().ok)
            {
                b = true;
            }
            else
            {
                b = false;
            }
        }
        else
        {
            b = false;
        }
        if (b)
        {
            GetComponent<spavnTablet>().SetValues = true;
            GetComponent<spavnTablet>().updateValue(buf.GetComponent<Taskability>().value);
            GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<spavnTablet>().SetValues = false;
            GetComponent<spavnTablet>().updateValue(0);
            GetComponent<spavnTablet>().updateText("");

        }
    }



    //void updateAnswer()
    //{
    //    bool buf;
    //    if(equation.Count == 1)
    //    {
    //        buf = equation[0].GetComponent<OperatorScript>().ok;
    //    }
    //    else
    //    {
    //        buf = false;
    //    }

    //    if(buf)
    //    {
    //        GetComponent<spavnTablet>().SetValues = true;
    //        GetComponent<spavnTablet>().updateValue(equation[0].GetComponent<Taskability>().value);
    //        GetComponent<BoxCollider>().enabled = true;
    //    }
    //    else
    //    {
    //        GetComponent<BoxCollider>().enabled = false;
    //        GetComponent<spavnTablet>().SetValues = false;
    //        GetComponent<spavnTablet>().updateValue(0);
    //        GetComponent<spavnTablet>().updateText("");

    //    }
    //}

}
