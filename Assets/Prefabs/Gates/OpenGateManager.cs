using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGateManager : MonoBehaviour {

    public GatesController gate;

    private void Start()
    {
        gate.OpenGates();
    }

}
