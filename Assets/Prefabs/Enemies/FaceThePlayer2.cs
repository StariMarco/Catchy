using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceThePlayer2 : MonoBehaviour {

    private Transform player;

    public RoundEnemyController enemy;

    private GameObject[] spawners = new GameObject[4];

    public float angle;
    private GameObject parentObject;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spawners[0] = GameObject.Find("SpawnerLeft");
        spawners[1] = GameObject.Find("SpawnerRight");
        spawners[2] = GameObject.Find("SpawnerTop");
        spawners[3] = GameObject.Find("SpawnerBottom");

        parentObject = transform.parent.gameObject;
    }

    void FixedUpdate()
    {
        if (enemy.canMove)
        {
            transform.right = player.position - transform.position;
        }
        else
        {
            if (parentObject.transform.position == spawners[0].transform.position || parentObject.transform.position == spawners[3].transform.position)
            {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, -angle);
            }
            else if (parentObject.transform.position == spawners[1].transform.position || parentObject.transform.position == spawners[2].transform.position)
            {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
        }
    }
}
