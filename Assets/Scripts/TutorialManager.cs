using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

    public GameObject playerBody;
    public float disableMovementTime;

    public float timeBefCountDown;
    public GameObject countDown;

    public GameObject spawnerTop;

    public GameObject TutorialRound;

    public GameObject[] hearts = new GameObject[3];
    int counter = 0;

    private void Start()
    {
        //for the start 6 seconds the player can't move
        playerBody.GetComponent<PlayerController>().DisablePlayerMovements(disableMovementTime);
        //do the countdown
        StartCoroutine(CountDown(timeBefCountDown));
    }

    IEnumerator CountDown(float t)
    {
        //wait for t seconds
        yield return new WaitForSeconds(t);
        //start count down
        GameObject c = Instantiate(countDown, new Vector3(0, 0, 0), Quaternion.identity);
        //delete the object after 4 seconds
        Destroy(c.gameObject, 4f);
        //load hearts
        StartCoroutine(LoadHearts());

        //---NEXT-------------------------------
        //wait 3 + 4 seconds and make the first enemy spawn
        StartCoroutine(SpawnFirstEnemy(7f));
    }

    IEnumerator LoadHearts()
    {
        //first heart
        hearts[counter].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        counter++;
        //second heart
        hearts[counter].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        counter++;
        //third heart
        hearts[counter].SetActive(true);
    }

    IEnumerator SpawnFirstEnemy(float t)
    {
        //wait for t seconds
        yield return new WaitForSeconds(t);
        //Instantiate first enemy
        spawnerTop.GetComponent<Spawner>().SpawnRedEnemy(true);
        //Start tutorial round
        TutorialRound.SetActive(true);
    }

}
