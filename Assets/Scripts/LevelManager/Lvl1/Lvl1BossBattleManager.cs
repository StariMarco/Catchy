using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1BossBattleManager : MonoBehaviour {

    public GameObject bossObj;
    public GameObject bossBody;
    public GameObject spawnParticleEffect;
    [Space]
    public float spawnWaitTime;

	void Start ()
    {
        //StartCoroutine(SpawnBoss(spawnWaitTime));
	}

    IEnumerator SpawnBoss(float t)
    {
        yield return new WaitForSeconds(t);
        //spawn boss animations
        bossObj.transform.position = new Vector3(24f, -0.13f, 0f);
        bossObj.SetActive(true);
    }
	
}
