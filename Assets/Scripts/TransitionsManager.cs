using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionsManager : MonoBehaviour {

    public Animator animator;
    public float waitTime;

    private void Start()
    {
        StartCoroutine(DestroySelf());
    }

    public void MoveUp()
    {
        animator.SetTrigger("Up");
    }

    public void MoveDown()
    {
        animator.SetTrigger("Down");
    }

    public void SawMoveLeft()
    {
        animator.SetTrigger("Left");
    }

    public void SawMoveRight()
    {
        animator.SetTrigger("Right");
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }

}
