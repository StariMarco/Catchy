using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropColor : MonoBehaviour {

    public void SetColor(Material mat)
    {
        gameObject.GetComponent<Renderer>().material = mat;
    }

}
