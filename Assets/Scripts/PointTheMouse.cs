using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTheMouse : MonoBehaviour {

    private Vector3 mousePos;
    private Vector3 lookPos;
    private float angle;

    void Update()
    {
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        lookPos = lookPos - transform.position;
        angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
