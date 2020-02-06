using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowEffect : MonoBehaviour {

    public Animator animator;

    public void EnterEffect()
    {
        animator.SetTrigger("Enter");
    }

    public void ExitEffect()
    {
        animator.SetTrigger("Exit");
    }

}
