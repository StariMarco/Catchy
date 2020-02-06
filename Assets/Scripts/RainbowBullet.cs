using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class RainbowBullet : MonoBehaviour {

    private Vector2 target;
    public float speed;
    public ParticleSystem bullectParticleEffect;
    public ParticleSystem dustEffect;

    public float shakeMagnitude, shakeRoughness, shakeFadeInTime, shakeFadeOutTime;
    private RipplePostProcessor mainCamera;

    void Start()
    {
        //setting the target of the bullet to the mouse click position
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RipplePostProcessor>();
    }


    void Update()
    {
        //move towards the mouse click point
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //destroy projectile and instatiate dust effect
        if (Vector2.Distance(transform.position, target) < 0.2f)
        {
            Instantiate(dustEffect, transform.position, Quaternion.identity);
            mainCamera.RippleEffect();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player") && !other.CompareTag("Drop") && !other.CompareTag("TransitionTriggers") && !other.CompareTag("Helper"))
        {
            //Instantiate bullet particle effect
            Instantiate(bullectParticleEffect, transform.position, Quaternion.identity);
            mainCamera.RippleEffect();
            //destroy if hits an object that isn't the player
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("GoldenBar"))
        {
            //damage the bar
            other.gameObject.GetComponent<GoldenBar>().health--;
            //if helath == 0 destroy it
            if(other.gameObject.GetComponent<GoldenBar>().health <= 0)
            {
                other.gameObject.GetComponent<GoldenBar>().DestroyBar();
            }
            //camera shake
            CameraShaker.Instance.ShakeOnce(shakeMagnitude, shakeRoughness, shakeFadeInTime, shakeFadeOutTime);
        }
    }
}
