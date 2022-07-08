using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class NoteScript : MonoBehaviour
{
    public bool spavn = false;
    public GivenNote given;
    public TextMesh text;
    public Text input;
    public float lentext;
    private float lenR;
    private bool l;
    void Start()
    {
        if (!spavn) 
        {
            text.text = GetComponent<Taskability>().Name + ":";            
        }
        l = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (l)
        {               
            GetComponent<ScalingTablet>().rW = 0.09f;
            GetComponent<ScalingTablet>().rL = 1.26f;
            l = false;
            SetSize();

        }
    }
    public void SetSize(float len = 9)
    {
        lenR = len;
        lentext = 2.65f * text.text.Length;
        given.gameObject.transform.localPosition = new Vector3
            (
                lenR / 2f + (lentext - lenR) / 2f + 0.9f,
                given.gameObject.transform.localPosition.y,
                given.gameObject.transform.localPosition.z
            );
        text.gameObject.transform.localPosition = new Vector3
            (
                -lentext / 2f + (lentext - lenR) / 2f - 0.7f,
                text.gameObject.transform.localPosition.y,
                text.gameObject.transform.localPosition.z
            );
        Debug.Log("lentext: " + lentext.ToString() + " position X: " + (-lentext / 2f + (lentext - lenR) / 2f));
        GetComponent<ScalingTablet>().replacementSaze(new Vector3(lentext - 1, 5, 0.1f), new Vector3(lenR - 1, 5, 0.1f));
        //GetComponent<ScalingTablet>().updateRwRL();
    }
    public void UpdateText()
    {
        if (!spavn)
        {
            return;
        }
        GetComponent<spavnTablet>().Name = input.text;
        text.text = GetComponent<spavnTablet>().Name + ":";
        l = true;
        if (PlayerPrefs.GetInt("Training") == 1)
        {
            GetComponent<spavnTablet>().Controller.Cursor.stopClick();
        }
    }
    public void translate()
    {
        given.translate();
    }
}
