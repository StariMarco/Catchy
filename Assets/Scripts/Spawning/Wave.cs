using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    public SpawnWaveOptions wave;

    private GameObject[] arrSpawners = new GameObject[4];

    private int numberOfEnemySpawned = 0;
    private int currentSpawner;

    public void Awake()
    {
        //get spawners into an array
        arrSpawners[0] = GameObject.Find("SpawnerTop");
        arrSpawners[1] = GameObject.Find("SpawnerRight");
        arrSpawners[2] = GameObject.Find("SpawnerBottom");
        arrSpawners[3] = GameObject.Find("SpawnerLeft");
    }

    public void Start()
    {
        //Instantiate enemies
        StartCoroutine(NextSpawn(numberOfEnemySpawned, wave.timeBtwSpawn));
    }

    IEnumerator NextSpawn(int numberOfEnemySpawned, float t)
    {
        //wait for t seconds
        yield return new WaitForSeconds(t);

        //Instantiate next enemy
        currentSpawner = wave.arrSpawnersOrder[numberOfEnemySpawned];
        Instantiate(wave.arrEnemy[numberOfEnemySpawned], arrSpawners[currentSpawner].transform.position, Quaternion.identity);
        numberOfEnemySpawned++;

        if (numberOfEnemySpawned < wave.enemyNumber)
            StartCoroutine(NextSpawn(numberOfEnemySpawned, t));
        else
            Destroy(gameObject);
    }

}
