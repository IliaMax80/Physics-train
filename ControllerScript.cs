using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControllerScript : MonoBehaviour
{
    public bool update;
    public int coin;
    public int colour;
    public GameObject answerGiven;
    public GameObject Active;
    public TrainingScript Cursor;
    public TrainingTabletScript Training;
    public GameObject paperСlip;
    public Vector2 max2, min2;
    public listObjects Tablet = new listObjects();
    public listObjects Given = new listObjects();
    public listObjects Operator = new listObjects();
    [SerializeField] private Text Coin;
    public List<GameObject> TabletList = new List<GameObject>();
    public List<GameObject> GivenList = new List<GameObject>();
    public List<GameObject> OperatorList = new List<GameObject>();
    public List<GameObject> Tab = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        colour = 0;
    }

    private void Update()
    {
        if (update)
        {
            TabletList = Tablet.list;
            GivenList = Given.list;
            OperatorList = Operator.list;

        }
    }

    // Vector3(89.51,45.54,27)
    // Vector3(121.6,45.54,27)
    public class listObjects
    {
        public List<GameObject> list;
        public listObjects()
        {
            list = new List<GameObject>();
        }
        public void add(GameObject a)
        {
            list.Add(a);

        }
        public void delet(GameObject a)
        {
            List<GameObject> buf = new List<GameObject>();
            foreach (GameObject b in list)
            {
                if (b != a)
                {
                    buf.Add(b);
                }
            }
            list = buf;
        }
    }


    //public void add(GameObject a)
    //{
    //    Tab.Add(a);
    //}
    //public void delet(GameObject a)
    //{
    //    List<GameObject> buf = new List<GameObject>();
    //    foreach (GameObject b in Tab)
    //    {
    //        if (b != a)
    //        {
    //            buf.Add(b);
    //        }
    //    }
    //    Tab = buf;
    //}


    public void SetSuit(int i)
    {
        if(i == 1 & PlayerPrefs.GetInt("Training") == 1 || i == 2 & PlayerPrefs.GetInt("Training") == 1)
        {
            Cursor.stopClick();
        }
        foreach (GameObject a in Tablet.list)
        {
            a.GetComponent<Taskability>().SetSuit(i);
            if (a.GetComponent<ScalingText>())
            {
                a.GetComponent<ScalingText>().UpdateScaling();
                
            }
        }

        colour = i;
        Active.transform.localPosition = new Vector3(-315 + 315 * i, 519.25f, 8);
        OldTables();
        //TODO: Тут нужен класс одтельный для операторов что бы вызывать у них перерендер во время изенений стилей - это ошибка ее исправит бы 
        //TODO: После еще нужно обучение продумать 
        //TODO: И можно мутить новые кейсы 
    }
    public void SetActiveGiven(bool b)
    {
        foreach(GameObject a in Given.list)
        {
            if(a != answerGiven)
            {
                a.GetComponent<Given>().SetMesh(b);
            }
        }
    }
    public void OldTables()
    {
        foreach(GameObject a in Operator.list)
        {
            if (a.GetComponent<OperatorScript>())
            {
                a.GetComponent<OperatorScript>().oldTable();
            }
        }
    }
    public void SetCoin(int a)
    {
        coin = a;
        //Coin.text = "Стоимость задачи: " + a.ToString();
        Coin.text = a.ToString();

    }
    public List<Vector3> GetPositionGiven()
    {
        List<Vector3> v = new();
        if(Given.list.Count > 1)
        {
            v.Add(Given.list[1].transform.position);
            v.Add(Given.list[2].transform.position);
        }
        else
        {
            v.Add(new Vector3(0, 0, 0));
            v.Add(new Vector3(0, 0, 0));
        }

        return v;
    }
    public Vector3 GetLastTablet()
    {
        if(Tablet.list.Count - 2 > -1)
        {
            return Tablet.list[Tablet.list.Count - 2].transform.position;
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }
    public Vector3 GetLastGiven()
    {
        Vector3 v = new Vector3();
        if (Tablet.list[Tablet.list.Count - 1].GetComponent<NoteScript>())
        {
            v = Tablet.list[Tablet.list.Count - 1].GetComponent<NoteScript>().given.gameObject.transform.position;
        }

        return v;
    }
    public void delet() 
    { 
        while(Operator.list.Count != 0)
        {
            Operator.list[0].GetComponent<Taskability>().delet();
        }
        while (Tablet.list.Count != 0)
        {
            Tablet.list[0].GetComponent<Taskability>().delet();
        }
    }
}
