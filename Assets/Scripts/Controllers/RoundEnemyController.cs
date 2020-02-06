using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEnemyController : MonoBehaviour {

    private GameObject player;
    public float speed;
    public bool canMove = false;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(EnableMovements());
	}
	
	void Update ()
    {
        //Move towards the player
        if(canMove)
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
	}

    IEnumerator EnableMovements()
    {
        //wait for 1 seconds
        yield return new WaitForSeconds(1f);
        canMove = true;
    }

}
