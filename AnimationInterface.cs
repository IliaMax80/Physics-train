using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInterface : MonoBehaviour
{
    // Start is called before the first frame update
    private bool l = false;
    public void anim()
    {
        if (l)
        {
            GetComponent<Animator>().SetBool("Start1-2", false);
            GetComponent<Animator>().SetBool("Start2-1", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Start1-2", true);
            GetComponent<Animator>().SetBool("Start2-1", false);
        }
        l = !l;
    }

}
