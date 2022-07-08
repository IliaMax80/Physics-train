using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TrainingScript : MonoBehaviour
{
    public bool anim;
    public bool click;
    public Vector3 clickPosition = new Vector3();
    public float speed = 16.3f; // в секунду
    public Vector2 v1, v2;
    public List<Vector3> lv1 = new List<Vector3>();
    public List<Vector3> lv2 = new List<Vector3>();
    public Animator animator;
    private Vector3 buf;
    private int i;


    void Start()
    {
        animator = GetComponent<Animator>();
        if (PlayerPrefs.GetInt("Training") == 0)
        {
            Destroy(gameObject);
        }
        StartCoroutine(Movement());
    }


    void Update()
    {
        //TODO: Ну я как решил еще одну функцую сделать пусть стопит с кроев и за кликаи следит передаем кардинаты в v1 и v2
        //TODO: Делаем там штуку с шагами самой аниации или типо того крч чекни блокнот   


    }

    public IEnumerator Movement()
    {
        if (anim)
        {
            float step = 1 / (Vector3.Distance(v1, v2) / speed) * 0.01f;
            for(float i = 0; i < 1.1; i += step)
            {
                yield return new WaitForSeconds(0.001f);

                buf = Vector3.Lerp(v1, v2, i);
                transform.position = new Vector3(buf.x, buf.y, 28);

            }
        }
        else
        {
            yield return new WaitForSeconds(0.01f);
            if (click)
            {
                transform.position = clickPosition;
                animator.SetBool("Сlick", true);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            }
        }
        StartCoroutine(Movement());

    }
    public void MovementPosition(List<Vector3> a, List<Vector3> b)
    {
        lv1 = a;
        lv2 = b;
        i = -1;
        stop1();
    }
    public void stopClick()
    {
        click = false;
        animator.SetBool("Сlick", false);
    }
    public void stop1()
    {
        i++;
        if(i >= lv1.Count)
        {
            anim = false;
            return;
        }
        v1 = lv1[i];
        v2 = lv2[i];
    }
    //public void MovementPositionV2(List<Vector3> a)
    //{

    //}
}
