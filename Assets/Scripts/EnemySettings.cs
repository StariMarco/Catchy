using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySettings : MonoBehaviour {

    public float health;
    [HideInInspector]
    public float startHealth;

    public string color;

    public bool isFirst = false;

    private void Start()
    {
        startHealth = health;
    }

}
