using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimating : MonoBehaviour {

    public Animator animator;

    private void Start()
    {
        StartCoroutine(DeactivateAnimation());
    }

    IEnumerator DeactivateAnimation()
    {
        yield return new WaitForSeconds(5f);
        //deactivate animator
        animator.enabled = false;
    }
}
