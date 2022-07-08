using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerScript : MonoBehaviour
{
    public float speed = -10; 
    public float MaxX = 100;
    public float MaxZ = 100;
    float Xs = 0;
    float Zs = 0;

    Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        Xs = transform.position.x;
        Zs = transform.position.z ;
        MaxX = MaxX / 2;
        MaxZ = MaxZ / 2 ;
    }

    // Update is called once per frame
    void Update()
    {   
        //таскабильность 
       if(Input.GetMouseButton(1)){
           transform.Translate(Input.GetAxis("Mouse X") * speed, 0, Input.GetAxis("Mouse Y") * speed); //xyz
       }
       //ограничители 
       if(transform.position.x > Xs + MaxX){
           transform.position = new Vector3(Xs + MaxX, transform.position.y, transform.position.z );
        }
        if(transform.position.x < Xs - MaxX ){
           transform.position = new Vector3(Xs - MaxX, transform.position.y, transform.position.z );
        }
        if(transform.position.z > Zs + MaxZ){
           transform.position = new Vector3(transform.position.x, transform.position.y, Zs + MaxZ);   
        }
        if(transform.position.z < Zs - MaxZ){
           transform.position = new Vector3(transform.position.x, transform.position.y,  Zs - MaxZ);
        }
        //тыкалка
        if(Input.GetMouseButtonDown(0)){
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit)){
                if(hit.collider.gameObject.tag == "home"){
                    Debug.Log("Ok2");
                }
            }
        }

    }
}
