using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public Text Input;
    public GameObject Field;
    public spavnTablet SpavnNumber;
    public spavnTablet SpavnNote;
    private int i = 0;
    void Start()
    {
        Field.SetActive(false);
    }

    public void Number()
    {
        i = 0;
        Field.SetActive(true);
        text.text = "¬ведите число";
        Field.GetComponent<InputField>().text = "";
    }
    public void Note()
    {
        i = 1;
        Field.SetActive(true);
        text.text = "¬ведите название";
        Field.GetComponent<InputField>().text = "";
    }
    public void Enter()
    {
        float a;
        switch (i)
        {
            case 0:
                if (float.TryParse(Input.text, out a))
                {
                    SpavnNumber.GetComponent<spavnTablet>().updateValue(a, false);
                    SpavnNumber.GetComponent<spavnTablet>().spavn(false);
                }
                break;
            case 1:
                SpavnNote.GetComponent<spavnTablet>().Name = Input.text;
                SpavnNote.GetComponent<spavnTablet>().spavn(false);
                break;
            default:
                break;
        }
        Field.SetActive(false);
    }
}
