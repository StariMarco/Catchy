using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayWithObject : MonoBehaviour {

    private Vector3 distanceFromObject;
    public GameObject otherObject;
    public string objectToFollowTag;

    private void Awake()
    {
        otherObject = GameObject.FindGameObjectWithTag(objectToFollowTag);
        distanceFromObject = transform.position - otherObject.transform.position;
    }

    void Update()
    {
        //stay with the other object
        transform.position = otherObject.transform.position + distanceFromObject;
    }
}
