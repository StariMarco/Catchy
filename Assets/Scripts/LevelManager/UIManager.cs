using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
/*
    public GameObject emptyWhiteBulletUI;
    public GameObject whiteBulletUI;
    public GameObject rainbowBulletUI;

    public float startSpawnRate;

    private float whitePosX = 5.3f;
    private float whitePosY = 5.3f;
    private float rainbowPosX = 5.3f;
    private float rainbowPosY = 4.6f;
    public float distance;

    public int whiteBulletNumber;
    public int rainbowBulletNumber;

    public int setupCounterWhite = 0;
    public int setupCounterRainbow = 0;
    public int positionIndex = 0;
    public int positionIndexRainbow = 0;

    public GameObject[] whiteBullets = new GameObject[8];
    public Vector2[] arrWhitePos = new Vector2[8];
    public GameObject[] arrWhitePositions = new GameObject[8];

    public GameObject[] rainbowBullets = new GameObject[8];
    public Vector2[] arrRainbowPos = new Vector2[8];

    public GameObject playerStats;
    public GameObject playerShooting;
    
    private void Start()
    {
        //Instantiate bullet bars
        StartCoroutine(UISetup(emptyWhiteBulletUI, whiteBulletNumber, whitePosX, whitePosY, arrWhitePos, setupCounterWhite));
        StartCoroutine(UISetup(emptyWhiteBulletUI, rainbowBulletNumber, rainbowPosX, rainbowPosY, arrRainbowPos, setupCounterRainbow));
    }

    private void Update()
    {
        //Update bullet bars
        whiteBulletbarUpdate();
        rainbowBulletbarUpdate();
    }

    public IEnumerator UISetup(GameObject g, int n, float x, float y, Vector2[] arrBullets, int counter)
    {
        //wait for time
        yield return new WaitForSeconds(startSpawnRate);
        //Instantiate 1 emptyBulletUI and saving it into an array
            Instantiate(g, new Vector3(x, y, 0f), Quaternion.identity);
        //saving the position
        arrBullets[counter] = new Vector2(x, y);
        x -= distance;

        //recalling the routin
        counter++;
        if (counter < n)
            StartCoroutine(UISetup(g, n, x, y, arrBullets, counter));
    }

    private void whiteBulletbarUpdate()
    {
        //if 1 bullet is added
        if (playerStats.GetComponent<PlayerStats>().add)
        {
            //Instatiate a whiteBulletUI and save it in an array
            whiteBullets[positionIndex] = Instantiate(whiteBulletUI, arrWhitePos[positionIndex], Quaternion.identity);
            positionIndex++;
            playerStats.GetComponent<PlayerStats>().add = false;
        }

        //if player shoots
        if (playerShooting.GetComponent<PlayerShoting>().shoot)
        {
            //delete 1 bullet from the array and destroy it
            positionIndex--;
            Destroy(whiteBullets[positionIndex]);
            playerShooting.GetComponent<PlayerShoting>().shoot = false;
        }
    }

    private void rainbowBulletbarUpdate()
    {
        //if 1 rainbow bullet is added
        if (playerStats.GetComponent<PlayerStats>().addRainbow && playerStats.GetComponent<PlayerStats>().rainbowBullet < rainbowBulletNumber + 1)
        {
            //Instatiate a rainbowBulletUI and save it in an array
            rainbowBullets[positionIndexRainbow] = Instantiate(rainbowBulletUI, arrRainbowPos[positionIndexRainbow], Quaternion.identity);
            positionIndexRainbow++;
            playerStats.GetComponent<PlayerStats>().addRainbow = false;
        }

        //if player shoots
        if (playerShooting.GetComponent<PlayerShoting>().shootRainbow)
        {
            //delete 1 bullet from the array and destroy it
            positionIndexRainbow--;
            Destroy(rainbowBullets[positionIndexRainbow]);
            playerShooting.GetComponent<PlayerShoting>().shootRainbow = false;
        }
    }
    */
}
