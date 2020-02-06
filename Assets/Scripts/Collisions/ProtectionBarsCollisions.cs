using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectionBarsCollisions : MonoBehaviour {

    public bool vertical, horizontal;
    public GameObject particleEffect;
    public Vector3 rotation;
    private GameObject bar;
    public Vector3 offset;

    public Animator animator;

    public GameObject electricity;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Instatiate particle effect
            if (vertical)
            {
                //Instantiate effect with 0° rotation
                bar = Instantiate(particleEffect, other.transform.position, Quaternion.identity);
                bar.transform.position += offset;
            }
            else
            {
                //Instantiate effect with 90° rotation
                bar = Instantiate(particleEffect, other.transform.position, Quaternion.Euler(rotation));
                bar.transform.position += offset;
            }

            //animating the bar
            animator.SetBool("IsColliding", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           //stop collision effect
            animator.SetBool("IsColliding", false);
        }
    }

    public void DestroyBar()
    {
        Destroy(gameObject);
    }

}
