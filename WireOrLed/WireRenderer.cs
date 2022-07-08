using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireRenderer : MonoBehaviour
{
    public bool update = false;
    public bool revers = false;
    public List<LineRenderer> WireLine = new List<LineRenderer>();
    public List<GameObject> Wire = new List<GameObject>();
    public List<WirePosition> NextLed = new List<WirePosition>();
    public int namberPath = 7;
    public int K = 10;
    //[SerializeField] public WirePosition NextLed;
    private Vector3 WirePositions;
    private int countlist;
    private int i, I, Ip, PathI;
    private Vector3 VectorOld, bufV;
    private float PathDlin, PathPosition, N, GN;
    // Start is called before the first frame update
    IEnumerator ok()
    {
        //Разные интересные вещи например вычисление количества точек и верхнего придела парабол
        yield return 1;
        GN = (Mathf.Pow(0.5f, 2) * K) - 0.2f;
        PathDlin = 1.0f / ((float)namberPath + 1.0f);
        I = 0;     
        countlist = NextLed.Count + 1 + (namberPath * NextLed.Count);

        //Пробигаемся по проводам 
        foreach (LineRenderer Line in WireLine)
        {
            //Передаем точку старта
            i = 0;
            Line.positionCount = countlist;
            if(revers == false)
            {
                Line.SetPosition(i, Wire[I].transform.position);
                VectorOld = Wire[I].transform.position;
            }
            else
            {
                Line.SetPosition(i, Wire[Wire.Count - 1 - I].transform.position);
                VectorOld = Wire[Wire.Count - 1 - I].transform.position;
            }

            PathPosition = 0;
            i++;
            //Идем к остальным точкам
            foreach (WirePosition a in NextLed)
            {   
                PathI = 0;
                PathPosition = 0;
                //Создание точек между ЛЭД
                while(PathI < namberPath)
                {
                    PathPosition += PathDlin;
                    bufV = Vector3.Lerp(VectorOld, a.WirePositions[I], PathPosition);              
                    N = Mathf.Pow(PathPosition - 0.5f, 2) * K;//ПАРАБАЛА 
                    bufV.y = bufV.y - GN + N;
                    Line.SetPosition(i, bufV);
                    
                    Debug.Log("I: " + I + " i: " + i + " VectorOld: " + VectorOld + " Position: " + a.WirePositions[I] + " N: " + N + " Vector: " + bufV + " GN: " + GN);

                    i++;
                    PathI++;




                }
                Line.SetPosition(i, a.WirePositions[I]);
                i++;

                /*WirePositions = a.WirePosition1;
                WireLine1.SetPosition(i, WirePositions);
                WirePositions = a.WirePosition2;
                WireLine2.SetPosition(i, WirePositions);
                WirePositions = a.WirePosition3;
                WireLine3.SetPosition(i, WirePositions);*/

                VectorOld = a.WirePositions[I];
            }
            I++;
        }
        
    }
    void Start()
    {   
        StartCoroutine(ok());
    }

    // Update is called once per frame
    void Update()
    {
        if (update)
        {
            StartCoroutine(ok());
        }
    }
    //Vector3[] PrintWireVector()
   // {
    //return new Vector3[3]{ Wire1.transform.position, Wire2.transform.position, Wire3.transform.position};
   // }
}
