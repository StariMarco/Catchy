using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Vector2 target;
	public float speed;
    public ParticleSystem bullectParticleEffect;
    public ParticleSystem dustEffect;

	void Start ()
    {
        //setting the target of the bullet to the mouse click position
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
	
	
	void Update ()
    {
        //move towards the mouse click point
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //destroy projectile and instatiate dust effect
        if (Vector2.Distance(transform.position, target) < 0.2f)
        {
            Instantiate(dustEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("Player") && !other.CompareTag("Drop") && !other.CompareTag("TransitionTriggers") && !other.CompareTag("Helper") && !other.CompareTag("DroppedStone"))
        {
            //Instantiate bullet particle effect
            Instantiate(bullectParticleEffect, transform.position, Quaternion.identity);
            //destroy if hits an object that isn't the player
            Destroy(gameObject);
        }
    }

}
