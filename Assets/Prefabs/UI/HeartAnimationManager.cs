using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAnimationManager : MonoBehaviour {

    public Animator animator;
    public float blinkWaitTime = 0, minWaitTime, maxWaitTime;

    private void Start()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            blinkWaitTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(blinkWaitTime);
            animator.SetTrigger("Blink");
        }
    }

    public void DestroyHeart()
    {
        animator.SetTrigger("Destroy");
        //yield return new WaitForSeconds(0.07f);
        gameObject.SetActive(false);
    }
}
