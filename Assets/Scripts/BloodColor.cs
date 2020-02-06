using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodColor : MonoBehaviour {

    public void SetColor(Material mat)
    {
        gameObject.GetComponent<Renderer>().material = mat;
    }

}
