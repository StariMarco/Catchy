using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceThePlayer : MonoBehaviour {

    private Transform player;

    public RoundEnemyController enemy;

    private GameObject[] spawners = new GameObject[4];

    public float angle;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spawners[0] = GameObject.Find("SpawnerLeft");
        spawners[1] = GameObject.Find("SpawnerRight");
        spawners[2] = GameObject.Find("SpawnerTop");
        spawners[3] = GameObject.Find("SpawnerBottom");
    }

    void FixedUpdate()
    {
        if (enemy.canMove)
        {
            transform.right = player.position - transform.position;
        }
        else
        {
            if(gameObject.transform.position == spawners[0].transform.position || gameObject.transform.position == spawners[3].transform.position)
            {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, -angle);
            }
            else if (gameObject.transform.position == spawners[1].transform.position || gameObject.transform.position == spawners[2].transform.position)
            {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
        }
    }
}
