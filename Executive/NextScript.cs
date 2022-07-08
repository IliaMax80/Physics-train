using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextScript : MonoBehaviour
{
    public Animator anim;
    [SerializeField] private ControllerScript Controller;
    [SerializeField] private GameObject barrierSmall;
    [SerializeField] private GameObject answer;
    [SerializeField] private GameObject Stic1;
    [SerializeField] private List<GameObject> Stics = new List<GameObject>();
    private bool l;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        l = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AnimNext() 
    {
        if(Stic1 != null)
        {
            Destroy(Stic1);
        }
        anim.SetBool("NextStart0", true);
        anim.SetBool("BackStart1", false);
        barrierSmall.GetComponent<BoxCollider>().enabled = false;
    }
    public void AnimIncorrect()
    {
        StartCoroutine(AI("incorrect"));
    }

    private IEnumerator AI(string a)
    {
        anim.SetBool(a, true);
        yield return new WaitForSeconds(1f);
        anim.SetBool(a, false);
    }
    private IEnumerator win()
    {

        yield return new WaitForSeconds(3f);
        if (PlayerPrefs.HasKey("NST"))
        {
            Debug.Log("+ 1 решенная задача");
            PlayerPrefs.SetInt("NST", PlayerPrefs.GetInt("NST") + 1);
            if (PlayerPrefs.HasKey("Coin"))
            {
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + Controller.coin);
            }

        }
        else
        {
            Debug.Log("Нет счетитчика");
        }
        SceneManager.LoadScene(1);
    }
    public void chek(float a)
    {
        if (Mathf.RoundToInt(answer.GetComponent<Given>().values() * 10) / 10.0f == Mathf.RoundToInt(a * 10) / 10.0f)
        {
            Debug.Log("задача решена");
            anim.SetBool("NextStart2", true);
            foreach(GameObject b in Stics)
            {
                if (b != null)
                {
                    Destroy(b);
                }
            } 
            StartCoroutine(win());
        }
        else
        {
            StartCoroutine(AI("incorrect2"));
        }
    }
    public void back()
    {
        anim.SetBool("NextStart0", false);
        if (!l)
        {
            anim.SetBool("BackStart1", true);
            anim.SetBool("NextStart1", false); 
            barrierSmall.GetComponent<BoxCollider>().enabled = true;
            l = true;
        }
        else
        {
            anim.SetBool("BackStart1", false);
            anim.SetBool("NextStart1", true);
            barrierSmall.GetComponent<BoxCollider>().enabled = false;
            l = false;
        }
        
       
    }
    public void exit()
    {
        SceneManager.LoadScene(1);
    }
}
