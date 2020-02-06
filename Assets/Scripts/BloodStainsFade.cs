using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodStainsFade : MonoBehaviour {

    private float lifeTime;
    public float minLifeTime, maxLifeTime, destroyTime;
    public Animator animator;

    private void Start()
    {
        lifeTime = Random.Range(minLifeTime, maxLifeTime);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        //wait for x seconds before go to the next room
        yield return new WaitForSeconds(lifeTime);
        //fade out the bloodStain
        animator.SetTrigger("FadeOut");
        //Destroy after x seconds
        Destroy(gameObject, destroyTime);
    }

}
