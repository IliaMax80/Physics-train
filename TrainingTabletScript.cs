using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TrainingTabletScript : MonoBehaviour
{
    public int step;
    public int Cursorstep;

    public ControllerScript Controller;
    public TrainingScript Cursor;
    public Text text;
    public List<string> words = new List<string>();
    void Start()
    {
        step = 0;
        if (PlayerPrefs.GetInt("Training") == 0)
        {
            Destroy(gameObject);
        }

        words.Add("� ���� �������� ���� ������� ����������� � ����������� ����, ������ � �������� ����� ������ ������ � ���� ���� ��������, " + //0
            "����� ����������.");

        words.Add("� ������ ��� ��������� ���������� �������� �� ���������� � ����, ��� �� ��� ��� ���� ������� ����� ����������� ����� " + //1
            "�����������. ����� �� ����� ������ �� ������� ������� ���������, ����� �� �������� �� ����������� ��������.");

        words.Add("�������� ��� ���� ����� ������� ����� �����������, �� ��� �� ����� ������ �������� �� ����� �������� ������� ������ �� ���." + //2
            " ������ � ������� ��������� ���������� �������� �� �� ������.");

        words.Add("��� �� ��������� ������������ ������ ������� ������� �� ������, ���� ��� �����, �� ��� ��������� �� ��������� ����, " + //3
            "� ��������� ������ ������� ��������� � ������� �������.");

        words.Add("�� ������ ������ ��������� � ������� ����� �<�, � ����� ��� ��������� ������ ������ ��������� ���������, �������� " + //4
            "� �������. �������������� �� � ������� �����. ������� ������� �������� ���������.");

        words.Add("��������� � ���� R2 � I2, ����� ����� U2 �� �������."); //5

        words.Add("�� ������ ����������� ������� ������ ���������� � ���������� �� ���� � �����, � ���������� ��������� ���������� " +
            "����� ������ � ��������� ���������, ������� ������� ������� ������."); //6

        words.Add("��� �� ������� �������� �������� ���������� ������ �� ����, � ����� �� ��������� ��������� �� ������ ����� ��� ������. " +
            "������� ������� ����� ������� � ��� �����."); //7

        words.Add("����� ������� �� ����� U2, ����� �� ������ �������� �� ����� �� ��������, ��� �� ������� ������������ � ������ ��������. " +
            "��� ����� ���� ����� �������� ��� ������� ������� ������ � ��� ��� ������ ����� ��� � �������� - �������."); //8

        words.Add("���� �������� ��� ��������� ����� ���� �����, ���� ������� ������������ ����� ���������� �������, ������� �� ������ ���������. " +
            "�������� ����� ������ ������ �� ������������ ��������, ������ �� ������ ������ ����� ����� �������� � ����� ������."); //9

        words.Add("������ U2 � ���� enter ��� �������������.������, ����� ���� �������� ������������ �� �������� �� ����� ��������."); //10

        words.Add("������ ��������� ��������� ���� �������� � ���� ��������, ����� ���� �� ������ ��� ����� ������ � ����� ����������� ��� " +
            "������������� � ������ ��������. �������� �������� � ��� ��� �� ������."); //11

        words.Add("�� ������ ������ ������� ����� �������� ������ ��������� �� � ��� ������, � ���� ��������."); //12

        words.Add("������ ������� U1 �� ������� U2 * K, ���� ���������, ��� �� ��� �� ������ �������� ������� ��� ����� ����������� � ������� " +
            "���� ��� ������. ����������� ������� �� ��������� ���������� ������� ��� �� �� ������� ���������."); //13

        words.Add("�� ���� ���, \n������� ����!"); //end
        text.text = words[step];
        //TODO: ����� ����� ����� ��� �� ������������ ��� ���� � VS
    }
    
    // Update is called once per frame
    void Update()
    {
        
        text.text = words[step];
    }
    public void next()
    {
        step++;
        if(step >= words.Count)
        {
            Destroy(Cursor.gameObject);
            Destroy(gameObject);
        }

        switch (step)
        {
            case 1:
                Cursor.click = true;
                Cursor.clickPosition = new Vector3(-18.9f, -22, 28);
                break;
            case 2:
                Cursor.anim = true;
                Cursor.stopClick();
                break;
            case 3:
                Cursor.anim = false;                
                Cursor.click = true;
                Cursor.clickPosition = new Vector3(66.8f, 31.1f, 28);
                break;
            case 4:
                Cursor.v1 = new Vector3(105.6f, -21.8f, 28);
                Cursor.v2 = new Vector3(143, 12.9f, 28);
                Cursor.anim = true;
                Cursor.stopClick();
                break;
            case 5:
                Cursor.MovementPosition(new List<Vector3>() { new Vector3(35.4f, 9.3f, 28), new Vector3(35.4f, 3.5f, 28)}, Controller.GetPositionGiven());
                break;
            case 6:
                Cursor.anim = false;
                Cursor.click = false;
                break;
            case 7:
                Cursor.anim = true;
                Cursor.v1 = new Vector3(148.7f, -20, 28);
                Cursor.v2 = new Vector3(167.7f, 1.7f, 28);
                break;
            case 8:
                Cursor.anim = false;
                Cursor.click = true;
                Cursor.clickPosition = new Vector3(109.1f, -29.6f, 28);
                break;
            case 9:
                Cursor.stopClick();
                break;
            case 10:
                Cursor.click = false;
                Cursor.anim = true;
                Cursor.v1 = new Vector3(142.5f, -30.2f, 28);
                Cursor.v2 = new Vector3(163.9f, 9.9f, 28);
                break;
            case 11:
                Cursor.anim = true;
                Cursor.v1 = Controller.GetLastTablet();
                Cursor.v2 = Controller.GetLastGiven();
                break;
            case 13:
                Cursor.anim = false;
                Cursor.click = true;
                Cursor.clickPosition = new Vector3(170.6f, 47.5f, 28);
                break;
            default:
                Cursor.click = false;
                Cursor.anim = false;
                break;

        }


    }
}
