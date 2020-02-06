using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new SpawnWave")]
public class SpawnWaveOptions : ScriptableObject {

    [Range(1, 5)]
    public int diffcultyLevel;
    public int enemyNumber;

    public GameObject[] arrEnemy;
    public int[] arrSpawnersOrder; //0 = top / 1 = right / 2 = bottom / 3 = left
    [Header("0 = top / 1 = right / 2 = bottom / 3 = left")]

    [Space]
    public float timeBtwSpawn;

}
