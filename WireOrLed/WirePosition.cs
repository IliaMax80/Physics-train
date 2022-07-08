using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePosition : MonoBehaviour
{
    public List<GameObject> Wire = new List<GameObject>();
    public List<Vector3> WirePositions = new List<Vector3>();
    private int i;


    private Vector3 vec;
    // Start is called before the first frame update
    void Start()
    {   
        i = 0;

        foreach(GameObject a in Wire)
        {
           WirePositions[i] = a.transform.position;
                i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
