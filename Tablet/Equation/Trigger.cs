using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool block; 
    public GameObject Trigger1, Trigger2;
    public GameObject Image, Arrow;

    private bool l;
    private Ray ray;
    private RaycastHit hit;
    private Vector3[] Old;
    private ScalingTablet Scaling;
    private OperatorScript Operator;

    private
    // Scalingart is called before the firScaling frame update
    void Start()
    {
        Scaling = GetComponent<ScalingTablet>();
        Operator = GetComponent<OperatorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (block)
        {
            Trigger1.GetComponent<BoxCollider>().enabled = false;
            Trigger2.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {

            Trigger1.GetComponent<BoxCollider>().enabled = true;
            Trigger2.GetComponent<BoxCollider>().enabled = true;
        } 
        l = false;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == Trigger1 | hit.collider.gameObject == Trigger2)
            {
                l = true;
            }
            if (Input.GetMouseButtonDown(0))
            {
                if(hit.collider.gameObject == Trigger2.gameObject)
                {
                    if (!Scaling.longForm)
                    {
                        Scaling.longForm = true;
                        Operator.oldTable(); 
                        Operator.SetPosition();
                        Operator.transizeLate();
                        Debug.Log("Down1");
                    }
                    else
                    {
                        Scaling.longForm = false;
                        Operator.oldTable();
                        Operator.SetPosition();
                        Operator.transizeLate();
                        Debug.Log("Down2");
                    }
                    
                }
            }
        }

        if (l)
        {
            Arrow.GetComponent<SpriteRenderer>().enabled = true;
            Image.GetComponent<SpriteRenderer>().enabled = true;

        }
        else
        {
            Arrow.GetComponent<SpriteRenderer>().enabled = false;
            Image.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void Translate(float x, float y, float smeh, bool l)
    {
        Image.transform.localPosition = new Vector3(x + 4.29f - smeh, 0, 0);
        Arrow.transform.localPosition = new Vector3(x + 4.73f - smeh, 0, -0.1f);
        Trigger1.transform.localPosition = new Vector3(x + 7f - smeh, 0, 0);
        Trigger2.transform.localPosition = new Vector3(x + 4.93f - smeh, 0, 0);
        if (!l)
        {
            Arrow.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            Arrow.GetComponent<SpriteRenderer>().flipX = true;
        }

    }
}

