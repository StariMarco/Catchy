using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBulletUI : MonoBehaviour {

    public Animator animator;

    private void Start()
    {
        //start animation
        animator.SetTrigger("Spawn");
    }

}
