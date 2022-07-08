using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivenNote : MonoBehaviour
{
    public NoteScript Note;
    public GameObject Table;
    private Taskability script;
    private bool l;

    void Start()
    {
        l = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (l)
        {
            if (Table != null)
            {
                if (!Table.GetComponent<Taskability>().bl)
                {
                    Table = Table.GetComponent<Taskability>().Transformation();
                    Table.GetComponent<spavnTablet>().Name = Note.GetComponent<Taskability>().Name;
                    Table.GetComponent<spavnTablet>().z = 29;
                    Table.GetComponent<Pinning>().enabled = false;
                    GetComponent<MeshCollider>().enabled = false;
                    //Note.transform.position = new Vector3(Note.transform.position.x, Note.transform.position.y, 29);
                    //transform.position = new Vector3(Note.transform.position.x, Note.transform.position.y, 29);
                    l = false;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Taskability>())
        {
            if (!other.GetComponent<Taskability>().bl)
            {
                return;
            }
            if (other.GetComponent<OperatorScript>() || other.GetComponent<NoteScript>())
            {
                return;
            }
            if (Table == null)
            {
                Table = other.gameObject;
                GetComponent<MeshRenderer>().enabled = false;
                script = Table.GetComponent<Taskability>();
                script.stop = true;
                script.stopPosition = transform.position;
                Note.SetSize(Table.GetComponent<ScalingTablet>().size.x);
            }
        }
    }
    //Выход
    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<Taskability>())
        {
            if (!other.GetComponent<Taskability>().bl)
            {
                return;
            }
            if (other.gameObject == Table)
            {
                GetComponent<MeshRenderer>().enabled = true;
                Table = null;
                script = other.GetComponent<Taskability>();
                script.stop = false;
                Note.SetSize();

            }

        }
    }

    public void translate()
    {
        if (Table != null)
        {
            if (Table.GetComponent<Taskability>())
            {
                Table.GetComponent<Taskability>().Translate(transform.position);
            }
            else
            {


                Table.transform.position = transform.position;
                //ghost.transform.position = new Vector3(StartVector.x, StartVector.y, StartVector.z);
            }
        }
    }
}

