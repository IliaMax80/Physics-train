using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilTurnsScript : MonoBehaviour
{   
    public float K;
    public int number;
    public GameObject prefab;
    private int N;
    private float offset, offsetUp, offsetDown;
    [SerializeField] private TransformerCore Core;
    private GameObject Coil;
    private List<GameObject> Clone = new List<GameObject>();
    private Vector3 StartVector;
    // Start is called before the first frame update
    void Start()
    {       
        StartVector = transform.position;
        upd();    
    }

    // Update is called once per frame
    void Update()
    {

    }
//*   
//Это расположение ветков 
    public void upd()
    {   
        N = new int[]{Core.n1, Core.n2}[number];
        transform.position = StartVector;
        foreach(GameObject a in Clone)
        {
            Destroy(a);
        }
        Clone = new List<GameObject>();
        offsetDown = 0; 
        offsetUp = 0;

        offset = transform.localScale.y / K; 
        //Debug.Log(offset);
        if(N % 2 == 0)
        {   
            transform.position = new Vector3(transform.position.x, transform.position.y - offset / 2.0f,transform.position.z);
            Coil = Instantiate(prefab) as GameObject;
            Coil.transform.position = new Vector3(transform.position.x, transform.position.y + offsetUp,transform.position.z);
            Clone.Add(Coil);
            offsetUp += offset;
        }
        for(int i = 0; i * 2 < N; i++)
        {
            Coil = Instantiate(prefab) as GameObject;  
            Coil.transform.position = new Vector3(transform.position.x, transform.position.y - offsetDown,transform.position.z);
            offsetDown += offset;
            Clone.Add(Coil);

            Coil = Instantiate(prefab) as GameObject;
            Coil.transform.position = new Vector3(transform.position.x, transform.position.y + offsetUp,transform.position.z);
            offsetUp += offset;
            Clone.Add(Coil);

        }
        foreach(GameObject a in Clone)
        {
            a.tag = tag;
            a.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y,transform.localScale.z);
        }     
    }
    //*/
}
