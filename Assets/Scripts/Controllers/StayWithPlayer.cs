using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayWithPlayer : MonoBehaviour {

    private GameObject player;
    private Vector3 offset;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //get the distance to manteing between the player and this object
        offset = transform.position - player.transform.position;
	}
	
	void Update ()
    {
        //stay with the player
        if(GameObject.FindGameObjectWithTag("Player"))
            transform.position = player.transform.position + offset;
	}
}
