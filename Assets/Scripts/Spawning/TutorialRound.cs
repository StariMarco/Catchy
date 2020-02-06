using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRound : MonoBehaviour {

    private GameObject[] arrDrops;
    [Space]
    public GameObject spawnManager;
    public GameObject helper;

    private int index = 0;

    private void FixedUpdate()
    {
        arrDrops = GameObject.FindGameObjectsWithTag("Drop");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (index == 1 && enemies.Length < 2)
        {
            //to Boss tutorial
            helper.SetActive(true);
            index++;
            gameObject.SetActive(false);
        }

        if (enemies.Length == 0)
        {
            if(arrDrops.Length == 0 && index == 0)
            {
                //Start Game
                Instantiate(spawnManager, transform.position, Quaternion.identity);
                index++;
                gameObject.SetActive(false);
            }
        }

    }

}
