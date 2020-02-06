using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowTrailEffect : MonoBehaviour {

    public GameObject trail;
    public float trailTimer;
    private float startTrailTimer;

    private void Start()
    {
        startTrailTimer = trailTimer;
    }

    void Update ()
    {
        //Trail effect
        TrailEffect();
    }

    private void TrailEffect()
    {
        if (trailTimer <= 0)
        {
            trailTimer = startTrailTimer;
            Instantiate(trail, transform.position, Quaternion.identity);
        }
        trailTimer -= Time.deltaTime * 5;
    }

}
