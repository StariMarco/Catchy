using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Cam_Transitions : MonoBehaviour {

    private CameraShaker mainCamera;
    public Vector3 targetPos;
    public GameObject previousRoom;
    public float waitTime;
    public GameObject tBox;
    public GameObject fogPane;
    public GameObject transitionFog;
    public GameObject playerBody;
    public float disableMovementTime;
    [Space]
    public GameObject[] uiComponents;
    public bool[] uiComponentsActivate;
    public float uiComponentsWaitTime;
    [Space]
    public UIMovements uiMovements = null;
    public GameObject gate;
    public PlayerStats playerStats;

    public void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShaker>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(NextRoom());

            //play sound
            FindObjectOfType<AudioManager>().PlaySound("Swoosh1");

            //translation effect
            Instantiate(tBox, transform.position, Quaternion.identity).GetComponent<TransitionsManager>().MoveUp();
            Instantiate(tBox, transform.position, Quaternion.identity).GetComponent<TransitionsManager>().MoveDown();
            //disable player movements fo x seconds
            playerBody.GetComponent<PlayerController>().DisablePlayerMovements(disableMovementTime);
        }
    }

    IEnumerator NextRoom()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        //wait for x seconds before go to the next room
        yield return new WaitForSeconds(waitTime);
        //move to the next room
        mainCamera.cameraPos = targetPos;
        previousRoom.GetComponent<BoxCollider2D>().enabled = true;
        //Update the fogPane
        if (this.gameObject.name == "MainToTransition")
        {
            fogPane.GetComponent<SpriteRenderer>().enabled = true;
            transitionFog.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            fogPane.GetComponent<SpriteRenderer>().enabled = false;
            transitionFog.GetComponent<SpriteRenderer>().enabled = true;
        }
        yield return new WaitForSeconds(uiComponentsWaitTime);
        //update ui
        if(uiComponents != null)
        {
            for(int i = 0; i<uiComponents.Length; i++)
            {
                uiComponents[i].SetActive(uiComponentsActivate[i]);
            }
        }
        //move ui elements
        if(uiMovements != null)
        {
            uiMovements.MoveUIComponents();
        }
        //open gate
        if(gate != null && playerStats.openGate)
        {
            gate.SetActive(true);
        }
    }

}
