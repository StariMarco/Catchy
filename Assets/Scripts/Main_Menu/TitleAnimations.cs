using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimations : MonoBehaviour {

    public Animator animator;

    public void RunExitAnimation()
    {
        animator.SetTrigger("Exit");
    }
}
