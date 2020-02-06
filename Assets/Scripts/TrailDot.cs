using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailDot : MonoBehaviour {

    public float scaleSpeed;

    void FixedUpdate()
    {
        //Decrease item scale while is > 0
        ReduceScale();
    }

    private void ReduceScale()
    {
        if (transform.localScale.x >= 0)
        {
            transform.localScale -= new Vector3(1, 1, 1) * scaleSpeed * Time.deltaTime;

        }
        else
        {
            Destroy(gameObject);
        }
    }

}
