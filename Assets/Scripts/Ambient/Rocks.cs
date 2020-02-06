using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour {

    public GameObject[] stones;
    public int maxStonesNumber, minStonesNumber;

    public Vector3 direction;
    [HideInInspector]
    public GameObject fatherObj;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            int n = Random.Range(minStonesNumber, maxStonesNumber);
            //destroy and spawn stones
            for(int i = 0; i<n; i++)
            {
                GameObject stone = Instantiate(stones[Random.Range(0, stones.Length)], transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                stone.GetComponent<StoneBehaviour>().direction = direction;
            }
            fatherObj.GetComponent<WallRockSpawner>().occupated = false;
            Destroy(gameObject);
        }
    }

}
