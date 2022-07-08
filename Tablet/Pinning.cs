using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinning : MonoBehaviour
{
    public GameObject paper—lip;
    private Vector3 r;
    // Start is called before the first frame update
    void Start()
    {
        paper—lip = GetComponent<spavnTablet>().Controller.paper—lip;
        r = paper—lip.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = paper—lip.transform.position - r;
    }
}
