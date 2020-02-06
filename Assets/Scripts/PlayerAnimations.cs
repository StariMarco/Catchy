using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {

    public Animator animator;
    private Animator eyeAnimator;
    private Animator bulletAnimator;
    private Animator rainbowBulletAnimator;

    private void Awake()
    {
        eyeAnimator = GameObject.Find("Eyes").GetComponent<Animator>();
        bulletAnimator = GameObject.Find("BulletSprite").GetComponent<Animator>();
        rainbowBulletAnimator = GameObject.Find("RainbowBulletSprite").GetComponent<Animator>();
    }

    public void mouseEnter()
    {
        //mouse over with drop animation
        if(animator != null)
        {
            animator.SetTrigger("MouseOver");
            eyeAnimator.SetTrigger("MouseOver");
            bulletAnimator.SetTrigger("MouseOver");
            rainbowBulletAnimator.SetTrigger("MouseOver");
        }
    }

    public void mouseExit()
    {
        //mouse away with drop animation
        if (animator != null)
        {
            animator.SetTrigger("MouseAway");
            eyeAnimator.SetTrigger("MouseAway");
            bulletAnimator.SetTrigger("MouseAway");
            rainbowBulletAnimator.SetTrigger("MouseAway");
        }
    }
}
