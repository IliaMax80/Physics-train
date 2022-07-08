using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spavnTablet : MonoBehaviour
{
    //Max:
    //Min: 
    public bool SetValues;
    public bool SetRoot;
    public Vector2 max;
    public Vector2 min;
    public Vector2 indentUD;
    public Vector2 indentRL;
    public float value;
    public string sing;
    public bool NotSuit = false;
    //public string tagScript;

    [SerializeField] public GameObject prefab1;
    

    public float z;
    //public bool limitation = false;
    public string Name;
    [SerializeField] public ControllerScript Controller;
    //public GameObject ghost;
    //public bool stop;
    //public Vector3 stopPosition;
    
    private GameObject bufObject;
    private Taskability Script;
    private Ray ray;
    private RaycastHit hit;
    public Vector3 StartVector;
    [SerializeField] private TextMesh txt;
    private Vector3 buf;
    private Vector3[] positionLine = new Vector3[5];// smesh;
    private Vector2 smeh;
    

    // Start is called before the first frame update
    void Start()
    {
        StartVector = transform.position;
        //z = StartVector.z;  
        //smesh = new Vector3(transform.position.x - ghost.transform.position.x, transform.position.y - ghost.transform.position.y, 0);
        max = Controller.max2;
        min = Controller.min2;
        positionLine[0] = new Vector3(min.x - indentRL.x, max.y + indentUD.x , z);
        positionLine[1] = new Vector3(max.x + indentRL.y, max.y + indentUD.x, z);
        positionLine[2] = new Vector3(max.x + indentRL.y, min.y - indentUD.y, z);
        positionLine[3] = new Vector3(min.x - indentRL.x, min.y - indentUD.y, z);
        positionLine[4] = new Vector3(min.x - indentRL.x, max.y + indentUD.x + 0.25f, z);

    }
    void Update()
    {
        //“˚Í?
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("dsdsd");
                if (hit.collider.gameObject == gameObject)
                {
                    spavn();
                }
            }
        }
    }
    public void updateValue(float v, bool l = true)
    {
        value = v;
        int a;
        a = Mathf.RoundToInt(v * 10);
        v = a / 10.0f;
        if (l)
        {
            txt.text = v.ToString();
        }
    }
    public void updateText(string a)
    {
        txt.text = a;
    }
    public void spavn(bool l = true)
    {
        if (l)
        {
            smeh.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            smeh.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
        buf.x = buf.x - smeh.x;
        buf.y = buf.y - smeh.y;
        bufObject = Instantiate(prefab1) as GameObject;
        bufObject.transform.position = transform.position;
        Script = bufObject.GetComponent<Taskability>();
        Script.StartMin = min;
        Script.StartMax = max;
        Script.z = z;
        Script.Name = Name;
        Script.sing = sing;
        Script.NotSuit = NotSuit;
        Script.InputSmeh(smeh);
        Script.limitation = false;
        Script.distroy = true;
        Script.Active—ursor();
        if (SetValues)
        {
            Script.UpdateValue(value);
        }
        if (SetRoot)
        {
            if (bufObject.GetComponent<OperatorScript>())
            {
                bufObject.GetComponent<OperatorScript>().Controller = Controller;
            }
        }
        if (GetComponent<SpavnOperator>())
        {
            GetComponent<SpavnOperator>().spavn(bufObject);
            Script.Controller = Controller;
            Controller.SetActiveGiven(true);
        }
        else
        {
            if (Controller != null)
            {
                Script.Controller = Controller;
                Controller.Tablet.add(bufObject);
                Script.SetSuit(Controller.colour);
                Controller.SetActiveGiven(true);
            }
        }
    }
}

