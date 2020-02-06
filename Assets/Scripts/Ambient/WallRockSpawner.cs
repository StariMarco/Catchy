using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRockSpawner : MonoBehaviour {

    public GameObject[] wallRocks;
    public bool occupated;

    private float timeBeforeSpawn;
    public float minTimeBeforeSpawn, maxTimeBeforeSpawn;

    public Vector3 spawnAngle;
    [Tooltip("0 = up, 1 = right, 2 = down, 3 = left")]
    public int direction; // 0 = up, 1 = right, 2 = down, 3 = left

    private void FixedUpdate()
    {
        //if there isn't a rock wait a random time and spawn one
        if (!occupated)
        {
            StartCoroutine(SpawnRock());
            occupated = true;
        }
    }

    IEnumerator SpawnRock()
    {
        timeBeforeSpawn = Random.Range(minTimeBeforeSpawn, maxTimeBeforeSpawn);
        yield return new WaitForSeconds(timeBeforeSpawn);

        GameObject[] rocks = GameObject.FindGameObjectsWithTag("WallRock");
        if(rocks.Length < 6)
        {
            //spawn rock
            GameObject rock = Instantiate(wallRocks[Random.Range(0, wallRocks.Length)], transform.position, Quaternion.Euler(spawnAngle));
            rock.GetComponent<Rocks>().fatherObj = gameObject;
            switch (direction)
            {
                case 0: //up
                    rock.GetComponent<Rocks>().direction = new Vector3(0f, 1f);
                    break;
                case 1: //right
                    rock.GetComponent<Rocks>().direction = new Vector3(1f, 0f);
                    break;
                case 2: //down
                    rock.GetComponent<Rocks>().direction = new Vector3(0f, -1f);
                    break;
                case 3: //left
                    rock.GetComponent<Rocks>().direction = new Vector3(-1f, 0f);
                    break;
            }
        }
    }

}
