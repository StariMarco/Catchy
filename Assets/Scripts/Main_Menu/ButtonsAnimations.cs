using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsAnimations : MonoBehaviour {

    public Animator animator;

    public void RunExitAnimation()
    {
        animator.SetTrigger("Exit");
    }

}
