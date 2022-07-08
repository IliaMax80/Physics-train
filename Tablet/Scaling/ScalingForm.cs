using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingForm : MonoBehaviour
{
    public bool update;
    public float length;
    public float width;
    public float R;
    public float ScaleZ;
    public GameObject Center, Right, Left, RU, RD, LU, LD;
    public GameObject[] parts;
    // Start is called before the first frame update
    void Start()
    {
        parts = new GameObject[] { Center, Right, Left, RU, RD, LU, LD };
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
        Center.transform.localScale = new Vector3(length, width, ScaleZ);

        Right.transform.localScale = new Vector3(R, width - R, ScaleZ);
        Right.transform.localPosition = new Vector3(length / 2, 0, 0);
        Left.transform.localScale = new Vector3(R, width - R, ScaleZ);
        Left.transform.localPosition = new Vector3(-length / 2, 0, 0);

        foreach (GameObject a in new GameObject[] {RU, RD, LU, LD })
        {
            a.transform.localScale = new Vector3(R, ScaleZ / 2f, R);
        }

        RU.transform.localPosition = new Vector3(length / 2, width / 2 - R / 2, 0);
        RD.transform.localPosition = new Vector3(length / 2, - width / 2 + R / 2, 0);
        LU.transform.localPosition = new Vector3(- length / 2, width / 2 - R / 2, 0);
        LD.transform.localPosition = new Vector3(- length / 2, - width / 2 + R / 2, 0);


    }
    public void updateTag(string a, GameObject root)
    {
        foreach(GameObject b in new GameObject[] { Center, Right, Left, RU, RD, LU, LD })
        {
            Debug.Log(b.name);
            b.tag = a;
            if (b.GetComponent<rootObject>())
            {
                b.GetComponent<rootObject>().root = root;
            }
        }
    }

}
