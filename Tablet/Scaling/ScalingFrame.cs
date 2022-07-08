using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingFrame : MonoBehaviour
{

    public bool update;
    public float length;
    public float width;
    public float R;
    public float z;
    public float ScaleZ;
    public GameObject Up, Down, Right, Left, RU, RD, LU, LD;
    public GameObject[] parts;
    // Start is called before the first frame update
    void Start()
    {
        //z = -0.07f;
        parts = new GameObject[] { Up, Down, Right, Left, RU, RD, LU, LD };
        UpdateForm();
    }

    // Update is called once per frame
    void Update()
    {
        if (update)
        {
            UpdateForm();
        }
    }
    public void UpdateForm()
    {
        Up.transform.localScale = new Vector3(length, R, ScaleZ);
        Up.transform.localPosition = new Vector3(0, width / 2, z);

        Down.transform.localScale = new Vector3(length, R, ScaleZ);
        Down.transform.localPosition = new Vector3(0, - width / 2, z);


        Right.transform.localScale = new Vector3(R, width, ScaleZ);
        Right.transform.localPosition = new Vector3(length / 2, 0, z);

        Left.transform.localScale = new Vector3(R, width, ScaleZ);
        Left.transform.localPosition = new Vector3(-length / 2, 0, z);

        foreach (GameObject a in new GameObject[] { RU, RD, LU, LD })
        {
            a.transform.localScale = new Vector3(R, ScaleZ / 2f, R);
        }

        RU.transform.localPosition = new Vector3(length / 2, width / 2, z);
        RD.transform.localPosition = new Vector3(length / 2, -width / 2, z);
        LU.transform.localPosition = new Vector3(-length / 2, width / 2, z);
        LD.transform.localPosition = new Vector3(-length / 2, -width / 2, z);


    }
    public void updateTag(string a, GameObject root)
    {
        foreach (GameObject b in new GameObject[] { Up, Down, Right, Left, RU, RD, LU, LD })
        {
            b.tag = a;
            if (b.GetComponent<rootObject>())
            {
                b.GetComponent<rootObject>().root = root;
            }
        }
    }
    public void smeh(float a)
    {
        transform.localPosition = new Vector3(a, transform.localPosition.y, transform.localPosition.z);
    }

}

