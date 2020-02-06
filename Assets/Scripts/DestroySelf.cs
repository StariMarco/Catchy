using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    private void FixedUpdate()
    {
        if(Vector2.Distance(gameObject.transform.position, player.transform.position) <= 0.2f)
        {
            //destroy if he hits the player
            Destroy(gameObject);
        }
    }

}
