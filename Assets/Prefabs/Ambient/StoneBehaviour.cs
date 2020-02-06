using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBehaviour : MonoBehaviour {

    public Vector3 direction;
    private Vector3 dirAngle;
    public float speed, movementDuration;
    [Space]
    public float minTimeToLive, maxTimeToLive;
    public Animator animator;

    private void Start()
    {
        dirAngle = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        StartCoroutine(ExitAnimation(Random.Range(minTimeToLive, maxTimeToLive)));
    }

    private void FixedUpdate()
    {
        if (movementDuration > 0)
        {
            transform.localPosition = transform.localPosition + (direction - dirAngle) * speed * Time.fixedDeltaTime;
            movementDuration -= Time.fixedDeltaTime;
            speed -= Time.fixedDeltaTime;
        }
    }

    IEnumerator ExitAnimation(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetTrigger("Exit");
    }

    public void DestroyStone()
    {
        Destroy(gameObject);
    }

}
