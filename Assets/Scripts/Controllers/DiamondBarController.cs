using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondBarController : MonoBehaviour {

    public Animator animator;

    public void CloseAnimation()
    {
        animator.SetTrigger("CloseBars");
    }

    public void OpenAnimation()
    {
        animator.SetTrigger("OpenBars");
    }

}
