using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1SpawnerManager : MonoBehaviour {

    public GameObject[] arrWaves;
    [Space]
    public float timeBtwWaves;
    private int waveIndex = 0;
    private int previusIndex = 0;
    private int totalDrops = 0;

    private PlayerStats playerStats;

    [HideInInspector]
    public GameObject tutorialRound;

    public void Awake()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        tutorialRound = GameObject.Find("TutorialRound");
    }

    private void Start()
    {
        //Instantiate a random wave spawner
        waveIndex = 0;
        //Instantiate(arrWaves[waveIndex], transform.position, Quaternion.identity);

        StartCoroutine(NextWave(timeBtwWaves, waveIndex));
    }

    IEnumerator NextWave(float t, int waveIndex)
    {

        while (totalDrops < Mathf.RoundToInt(playerStats.maxDropNumber))
        {
            //getting the total drops amount
            GameObject[] arrDropsOnTheGround = GameObject.FindGameObjectsWithTag("Drop");
            totalDrops = (Mathf.RoundToInt(playerStats.collectedDropNumber + (playerStats.rainbowBullet * playerStats.maxDropNumber))) + arrDropsOnTheGround.Length;

            //wait for t seconds
            if (waveIndex == 0)
                yield return new WaitForSeconds(3f);
            else
                yield return new WaitForSeconds(t);

            if (totalDrops < Mathf.RoundToInt(playerStats.maxDropNumber))
            {

                //Instantiate a random wave spawner
                Instantiate(arrWaves[waveIndex], transform.position, Quaternion.identity);

                //new random index
                while (previusIndex == waveIndex)
                {
                    waveIndex = Random.Range(1, arrWaves.Length);
                }
                previusIndex = waveIndex;

                //Decrease the time btw spawn
                if (t > 7)
                    t -= 0.25f;
            }
            
        }

        //setActive tutorial round for the next tutorial sequence
        tutorialRound.gameObject.SetActive(true);
        //destroy this object
        Destroy(gameObject);
        yield break;

    }

}
