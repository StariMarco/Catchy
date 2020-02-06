using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private Vector2 direction;
    public float speed;

    public bool canMove = true;

    public GameObject[] bulletSprites;
    private int bulletIndex = 0;

    public ParticleSystem walkParticles;

    public GameObject pauseMenu;
    public GatesController gate;

    private void Start()
    {
        //set the raimbow bullet to inactive
        bulletSprites[1].SetActive(false);
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            //Check if the player wants to move
            CheckDirection();
            //Moving
            Move();
            //mouse scroll wheel
            if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
            {
                UpdateBulletSprite();
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
            {
                UpdateBulletSprite();
            }
        }
        //Additional input controlls
        InputControlls();
    }

    private void UpdateBulletSprite()
    {
        //deactivate the previous sprite
        bulletSprites[bulletIndex].SetActive(false);
        //increase bulletIndex
        bulletIndex = (bulletIndex + 1) % bulletSprites.Length;
        //activate the sprite
        bulletSprites[bulletIndex].SetActive(true);
    }

    void InputControlls()
    {
        // DEBUG
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        // PAUSE MENU
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        // DEBUG ENEMY NUMBER
        if (Input.GetKeyUp(KeyCode.I))
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Debug.Log("Enemy number: " + enemies.Length);
        }
    }

    void CheckDirection()
    {
        //resetting direction
        direction = Vector2.zero;

        //checking Inputs
        //UP
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        //DOWN
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        //LEFT
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        //RIGHT
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }

    public void Move()
    {
        //moving ( .normalized -> make it move at the same speed eveng when is moving diagonally)
        transform.Translate(direction.normalized * speed * Time.deltaTime);
        //particles
        if(direction != Vector2.zero)
            Instantiate(walkParticles, transform.position, Quaternion.identity);
    }

    public void DisablePlayerMovements(float time)
    {
        canMove = false;
        StartCoroutine(EnablePlayerMovements(time));
    }

    IEnumerator EnablePlayerMovements(float time)
    {
        //wait for x seconds 
        yield return new WaitForSeconds(time);
        //enable movements
        canMove = true;
    }

}
