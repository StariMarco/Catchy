using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMouseAnimations : MonoBehaviour {

    public Animator animator;

    private Vector3 offset;

    private bool isCollidingWithPlayer = false;
    private bool dragging = false;

    private PlayerStats playerStats;

    private PlayerAnimations playerAnimations;

    private Vector3 previousPos;

    public bool isFirst = false;
    public GameObject cursorAnimation;
    private GameObject cursor;

    private RipplePostProcessor mainCamera;

    public GlowEffect glowEffect;

    private void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        playerAnimations = GameObject.Find("Body").GetComponent<PlayerAnimations>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RipplePostProcessor>();

        //tutorial
        if(isFirst)
            StartCoroutine(StartTutorialDropAnimation());
    }

    void OnMouseDown()
    {
        //calculate the offset between the object and the mouse position
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        dragging = true;

        //updating previous pos
        previousPos = gameObject.transform.GetChild(0).transform.position;
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    private void OnMouseUp()
    {

        //if the player drops it out of the game area it returns back to the previous position
        if (IsOutOfTheScreen())
        {
            transform.position = previousPos;
            return;
        }

        //update the cursor tutorial animation
        if (isFirst)
        {
            //saving the actual drop position so if the player drops it out of the game area it returns back
            cursor.GetComponent<MoveTowardsObject>().startPosition = transform.position;
            cursor.transform.position = transform.position;
        }
        
        dragging = false;
        //stop player animation
        playerAnimations.mouseExit();
        //if drop item is over player and user release mouse button delete the drop item
        if (isCollidingWithPlayer)
        {
            //destroy the cursor animation obj
            if (isFirst)
                Destroy(cursor.gameObject);
            //ripple effect
            mainCamera.RippleEffect();
            //play sound
            float pitch = Random.Range(0.75f, 1.50f);
            FindObjectOfType<AudioManager>().PlaySound("DropCollect", pitch);
            //add 1 to the drop counter and update UI
            DestroyDrop();
        }
    }

    private void OnMouseEnter()
    {
        //When the mouse is over set the animaton
        animator.SetTrigger("MouseOver");
        //glow effect
        glowEffect.EnterEffect();
    }
    private void OnMouseExit()
    {
        //When the mouse exits set the exit animaton
        animator.SetTrigger("MouseAway");
        //glow effetc
        glowEffect.ExitEffect();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (dragging)
            {
                isCollidingWithPlayer = true;
                //player animation
                playerAnimations.mouseEnter();
            }
            /*else //if the player collide with the drop item and the user is not dragging it
                DestroyDrop();*/
        }
    }

    private void DestroyDrop()
    {
        playerStats.collectedDropNumber++;
        if(playerStats.collectedDropNumber >= playerStats.maxDropNumber)
        {
            if(playerStats.rainbowBullet < playerStats.maxRainbowNumber)
            {
                //get 1 rainbow bullet
                playerStats.rainbowBullet++;
                //Update UI
                playerStats.addRainbow = true;
            }
            //reset drop counter
            playerStats.collectedDropNumber = 0;
        }
        Destroy(gameObject);
    }

    private bool IsOutOfTheScreen()
    {
        return (transform.position.y > 5.65f || transform.position.x > 5.65f || transform.position.y < -5.65f || transform.position.x < -5.65f);
    }

    IEnumerator StartTutorialDropAnimation()
    {
        //wait for 1 seconds
        yield return new WaitForSeconds(1f);
        //Instantiate cursor animation
        cursor = Instantiate(cursorAnimation, transform.position, Quaternion.identity);
    }

}
