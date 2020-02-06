using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowHealthbarFix : MonoBehaviour {

    public GameObject enemy;

    private void FixedUpdate()
    {
        transform.position = enemy.transform.position + new Vector3(0, 0.598f);
    }

}
