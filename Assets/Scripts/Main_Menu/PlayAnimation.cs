using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour {

    public Animator animator;

    public void RunPlayAnimation()
    {
        animator.SetTrigger("Play");
    }

}
