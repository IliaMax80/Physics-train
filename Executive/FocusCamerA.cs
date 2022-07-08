using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCamerA : MonoBehaviour
{
    
    // Start is called before the first frame update
    public float speed = 1;
    public float focusMax = 50;
    float MouseWheel = 0;
    float Zs; 
    float Ys;
    void Start()
    {
        Zs = transform.localPosition.z;
        Ys = transform.localPosition.y;
         
        transform.localPosition = new Vector3(transform.localPosition.x, Ys, Zs);
    }

    // Update is called once per frame
    void Update()
    {
        MouseWheel = Input.GetAxis("Mouse ScrollWheel"); 
        if(MouseWheel < -0.1){
            transform.Translate(0, 0, -speed);
        }
        if(MouseWheel > 0.1){
        if(Zs + focusMax > transform.localPosition.z){
            transform.Translate(0, 0, speed);
            }
        }
        if(Zs > transform.localPosition.z){
            transform.localPosition = new Vector3(transform.localPosition.x, Ys, Zs);
        }
    

    }
}
