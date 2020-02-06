using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBulletManager : MonoBehaviour {

    public Animator animator;

    public void ActivateBulletUI()
    {
        animator.SetBool("Active", true);
    }

    public void DeactivateBulletUI()
    {
        animator.SetBool("Active", false);
    }
}
