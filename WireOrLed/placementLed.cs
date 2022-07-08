using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placementLed : MonoBehaviour
{   
    public bool update = false;
    public WireRenderer ren;
    [SerializeField] public GameObject NextLed;
    [SerializeField] public GameObject prefadLed;
    public float rotation = 0;
    public int namberLed; 
    private float distanceLed;
    private Vector3 pstart, pend;
    private GameObject Led;
    private float distance;
    private List<GameObject> Clone = new List<GameObject>(); 


    // Автоматичиская растоновка ЛЭД
    void Start()
    {   

        Debug.Log(rotation);
        pstart = transform.position;
        pend = NextLed.transform.position;
        ren = GetComponent<WireRenderer>();
        ren.NextLed = new List<WirePosition>();
        distance = 0;
        if(Clone.Count != 0){
            foreach(GameObject a in Clone)
            {
                Destroy(a);
            }
            Clone = new List<GameObject>();
        }
        if(namberLed != 0){

            distanceLed = 1.0f / ((float)namberLed + 1.0f);
            for(int i = 0; i < namberLed; i++){
                Debug.Log("i: " + i + "distance: " + distance);
                distance += distanceLed;
                Led = Instantiate(prefadLed) as GameObject;
                Led.transform.eulerAngles = new Vector3(0, rotation, 0);
                Led.transform.position = Vector3.Lerp(pstart, pend, distance);
                ren.NextLed.Add(Led.GetComponent<WirePosition>());
                Clone.Add(Led);
            }
            
        }
        ren.NextLed.Add(NextLed.GetComponent<WirePosition>());
        //Vector3
    }

    // Update is called once per frame
    void Update()
    {
        if(update)
        {
            Start();
        }
    }
}
