using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingFormB : MonoBehaviour
{
    public bool update;
    public float lengthR;
    public float lengthL;
    public float width;
    public float R;
    public float ScaleZ;
    public GameObject CenterR, CenterL, Right, Left, RU, RD, LU, LD;
    public GameObject[] parts;
    // Start is called before the first frame update
    void Start()
    {
        parts = new GameObject[] { CenterR, CenterL, Right, Left, RU, RD, LU, LD };
    }

    //Update is called once per frame
    void Update()
    {
        if (update)
        {
            UpdateForm();
        }
    }
    public void UpdateForm()
    {
        CenterR.transform.localScale = new Vector3(lengthR, width, ScaleZ);
        CenterR.transform.localPosition = new Vector3(lengthR / 2, 0, 0);
        CenterL.transform.localScale = new Vector3(lengthL, width, ScaleZ);
        CenterL.transform.localPosition = new Vector3(-lengthL / 2, 0, 0);

        Right.transform.localScale = new Vector3(R, width - R, ScaleZ);
        Right.transform.localPosition = new Vector3(lengthR, 0, 0);

        Left.transform.localScale = new Vector3(R, width - R, ScaleZ);
        Left.transform.localPosition = new Vector3(-lengthL, 0, 0);

        foreach (GameObject a in new GameObject[] { RU, RD, LU, LD })
        {
            a.transform.localScale = new Vector3(R, ScaleZ / 2f, R);
        }

        RU.transform.localPosition = new Vector3(lengthR, width / 2 - R / 2, 0);
        RD.transform.localPosition = new Vector3(lengthR, -width / 2 + R / 2, 0);
        LU.transform.localPosition = new Vector3(-lengthL, width / 2 - R / 2, 0);
        LD.transform.localPosition = new Vector3(-lengthL, -width / 2 + R / 2, 0);


    }
    public void updateTag(string a, GameObject root)
    {
        foreach (GameObject b in parts)
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
