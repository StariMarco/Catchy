using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToBossTutorialManager : MonoBehaviour {

    public GameObject mouseScrollText;
    public GameObject destroyText;
    public GameObject tryAgainText;

    private GameObject instance;

    private PlayerStats player;

    private int firstText = 0;

    //NEW DIALOGUE SYSTEM

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerStats>();
        //create the first tutorial text
        instance = Instantiate(mouseScrollText);
    }

    public void Update()
    {
        //if the player use the scroll wheel delete the current text and load the next
        if(firstText == 0 && Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            firstText++;
            instance.gameObject.GetComponent<Animator>().SetTrigger("Destroy");
            Destroy(instance, 0.6f);
            StartCoroutine(NextText(destroyText, 1f));
        }

        if(firstText == 1 && Input.GetMouseButtonUp(0))
        {
            firstText++;
            //destroy the second text
            instance.gameObject.GetComponent<Animator>().SetTrigger("Destroy");
            StartCoroutine(TryAgain());
            Destroy(instance, 0.6f);
            instance = null;
        }
    }

    IEnumerator NextText(GameObject text, float t)
    {
        instance = Instantiate(destroyText);
        instance.SetActive(false);
        yield return new WaitForSeconds(t);
        //instantiate next text
        instance.SetActive(true);
    }

    IEnumerator TryAgain()
    {
        yield return new WaitUntil(() => player.rainbowBullet == 0);
        yield return new WaitForSeconds(1.5f);
        //if the gate has been destroyed
        if (GameObject.FindGameObjectsWithTag("GoldenBar").Length == 0)
        {
            instance.gameObject.GetComponent<Animator>().SetTrigger("Destroy");
            Destroy(instance, 0.6f);
            yield break;
        }

        //if the player doesn't destroy the golden bar let him retry
        player.rainbowBullet++;
        player.addRainbow = true;
        //try again text
        if(instance == null)
            instance = Instantiate(tryAgainText);

        StartCoroutine(TryAgain());
    }

}
