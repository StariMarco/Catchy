using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDrop : MonoBehaviour {

    public Vector3 direction;
    public float speed;
    public float timeBeforeDestroy;

    public GameObject objToSpawn;

    private void FixedUpdate()
    {
        //move towards 1 direction
        transform.position = transform.position + (direction * speed * Time.fixedDeltaTime);
        timeBeforeDestroy -= Time.fixedDeltaTime;
        speed -= Time.fixedDeltaTime;
        //destroy and spawn the obj
        if (timeBeforeDestroy < 0)
            Destroy();
    }

    private void Destroy()
    {
        if (!IsOutOfTheScreen())
        {
            //instantiate particle effect
            //instantiate gameObject with random rotation
            Instantiate(objToSpawn, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        }
        //destroy
        Destroy(gameObject);
    }
    private bool IsOutOfTheScreen()
    {
        return (transform.position.y > 5.65f || transform.position.x > 5.65f || transform.position.y < -5.65f || transform.position.x < -5.65f);
    }

}
