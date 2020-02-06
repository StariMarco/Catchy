using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour {

    private Vector3 distanceFromCenter;
    public GameObject player;

    private void Awake()
    {
        distanceFromCenter = transform.position - player.transform.position;
    }

    void Update ()
    {
        //stay with the player body
        transform.position = player.transform.position + distanceFromCenter;
	}
}
