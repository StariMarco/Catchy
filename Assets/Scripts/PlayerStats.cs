using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float health;
    [HideInInspector]
    public float startHealth;
    [HideInInspector]
    public float collectedDropNumber = 0;
    public float maxDropNumber;

    [HideInInspector]
    public int whiteBullets;
    public int maxWhiteBullets;
    //[HideInInspector]
    public int rainbowBullet = 0;
    public float whiteBulletTimeRate;
    public int maxRainbowNumber;
    [HideInInspector]
    public bool add = false;
    public bool addRainbow = false;

    public PlayerController plController;

    public int collectedKey = 0;
    public int KeyAmount;
    //[HideInInspector]
    public bool openGate = false;

    private void Start()
    {
        startHealth = health;
        StartCoroutine(AddingBullets());
    }

    IEnumerator AddingBullets()
    {
        //wait for 1 seconds
        yield return new WaitForSeconds(whiteBulletTimeRate);
        if (plController.canMove)
        {
            //give to the player a white bullets
            if (whiteBullets < maxWhiteBullets)
            {
                whiteBullets++;
                add = true;
            }
        }
        StartCoroutine(AddingBullets());
    }

}
