using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceIconManager : MonoBehaviour {

    public Animator animator;
    public GameObject helper;
    [HideInInspector]
    public bool activated = false;

    public void Activate()
    {
        animator.SetBool("Activated", true);
        activated = true;
    }

    public void Deactivate()
    {
        animator.SetBool("Activated", false);
        activated = false;
    }
}
