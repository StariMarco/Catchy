using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject redEnemy;
    public GameObject greenEnemy;
    public GameObject yellowEnemy;

    public void SpawnRedEnemy(bool isFirst)
    {
        //spawn red enemy
        if (isFirst)
        {
            //instantiate the enemy and tell him that is the first
            GameObject e = Instantiate(redEnemy, transform.position, Quaternion.identity);
            e.GetComponent<EnemySettings>().isFirst = true;
        }
        else
            Instantiate(redEnemy, transform.position, Quaternion.identity);
    }

    public void SpawnGreenEnemy()
    {
        //spawn red enemy
        Instantiate(greenEnemy, transform.position, Quaternion.identity);
    }

}
