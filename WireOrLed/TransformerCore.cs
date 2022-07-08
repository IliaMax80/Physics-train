using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformerCore : MonoBehaviour
{   
    [SerializeField] private CoilTurnsScript Coil1, Coil2;
    public int n1, n2;
    public float speedWheel;
    private string number1, number2;
    private Vector3 bufVector;
    private int i; 
    private Ray ray;
    private RaycastHit hit;
    private float MouseWheel;
    public float K;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //Крутилка значений
        K = (float) n1 / (float) n2;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {   
            MouseWheel = Input.GetAxisRaw("Mouse ScrollWheel");
            if(MouseWheel < -0.1){  i = -1; }
            else if(MouseWheel > 0.1){   i =  1; }
            else{ i = 0;}
            if(hit.collider.gameObject.tag == "Trann1"){    Shift1(i);  }
            if(hit.collider.gameObject.tag == "Trann2"){    Shift2(i);  }
                    
                

        }
        
    

    }
    //Функции изменение велечин для колесика мыши 
    public void Shift1(int a)
    {   
        if(n1 + a > 0)
        {    
        n1 += a;
        Coil1.upd();
        }
    }
    public void Shift2(int a)
    {   
        if(n2 + a > 0)
        {    
        n2 += a;
        Coil2.upd();
        }

    }

}
