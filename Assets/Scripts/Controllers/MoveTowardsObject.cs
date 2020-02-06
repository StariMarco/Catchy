using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour {

    private GameObject targetObject;
    public float speed;

    public Vector2 startPosition;

    public void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag("Player");
        startPosition = transform.position;
    }

    public void FixedUpdate()
    {
        //move towards object
        transform.position = Vector2.MoveTowards(transform.position, targetObject.transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetObject.transform.position) < 0.5f)
        {
            //reset to start position
            transform.position = startPosition;
        }
    }

}
