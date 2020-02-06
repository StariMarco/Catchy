using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesController : MonoBehaviour {

    public Animator animator;
    public float waitTime;

    public Animator[] protectionBarsAnim;

	public void OpenGates()
    {
        //start open animation
        animator.SetBool("Open", true);
        for(int i = 0; i<protectionBarsAnim.Length; i++)
        {
            protectionBarsAnim[i].SetTrigger("Deactivate");
        }
    }

}
