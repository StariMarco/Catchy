using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAnimation : MonoBehaviour {

    private float x, y;
    private Vector3 vec;
    public float min, max;

    private void Start()
    {
        //Random x in range [-max, -min] U [min, max]
        float[] xCandidates = { Random.Range(-max, -min), Random.Range(min, max) };
        int idx = Random.Range(0, 2); 
        x = xCandidates[idx];
        //Random y in range [-max, -min] U [min, max]
        float[] yCandidates = { Random.Range(-max, -min), Random.Range(min, max) };
        idx = Random.Range(0, 2); 
        y = yCandidates[idx];
    }

    private void Update()
    {
        if (x > 0 || y > 0)
        {
            vec = new Vector2(x, y);
            x -= Time.deltaTime * 0.5f;
            y -= Time.deltaTime * 0.5f;
            transform.position = transform.position + vec;
        }
    }

}
