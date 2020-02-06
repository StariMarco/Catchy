using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenBar : MonoBehaviour {

    public int health;
    public GameObject particleEffect;
    public GameObject flashEffect;
    public PlayerRaycast playerRay;
    public GameObject helper;

    public void DestroyBar()
    {
        //disable helper
        helper.GetComponent<Animator>().SetTrigger("Exit");
        //flash effect
        Instantiate(flashEffect);
        //instantiate particle effect
        Instantiate(particleEffect, transform.position, Quaternion.identity);
        //enable raycast2d
        playerRay.EnablerRay();
        Destroy(gameObject);
    }

}
