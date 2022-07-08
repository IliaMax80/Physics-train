using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blumb : MonoBehaviour
{
    // Анимацие уведомлений над домами
    [SerializeField] public Animator anim;
    public GameObject Obj;

    void Start()
    {   
        // anim = GetComponent<Animator>();
        // Пока что 
        StartCoroutine(apperance());

        Obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator apperance(){
        yield return new WaitForSeconds(3);
        Obj.SetActive(true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("bool", true);

    }
    public void falsebool(){
        anim.SetBool("bool", false);
    }
}
