using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKeyManager : MonoBehaviour {

    public Animator animator;
    public Animator playerAnimator;
    public Animator playerEyesAnimator;

    private Vector3 offset;
    private Vector3 previousPos;
    private bool dragging = false;
    private bool isCollidingWithPlayer = false;

    public GameObject targetUIKey;
    public GameObject uIKeyFull;
    public float speed;

    public Animator diamondBarAnimator;

    void OnMouseDown()
    {
        //calculate the offset between the object and the mouse position
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        dragging = true;

        //updating previous pos
        previousPos = transform.position;
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    private void OnMouseUp()
    {
        dragging = false;

        if (isCollidingWithPlayer)
        {
            //collect the key
            animator.SetBool("MouseOver", false);
            StartCoroutine(MoveToKeyBar());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (dragging)
            {
                isCollidingWithPlayer = true;
                playerAnimator.SetTrigger("MouseOver");
                playerEyesAnimator.SetTrigger("MouseOver");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
            playerAnimator.SetTrigger("MouseAway");
            playerEyesAnimator.SetTrigger("MouseAway");
        }
    }

    private void OnMouseEnter()
    {
        animator.SetBool("MouseOver", true);
    }

    private void OnMouseExit()
    {
        animator.SetBool("MouseOver", false);
    }

    private IEnumerator MoveToKeyBar()
    {
        while(Vector2.Distance(transform.position, targetUIKey.transform.position) > 0.2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetUIKey.transform.position, speed * Time.deltaTime);
            if (speed < 20f)
                speed += Time.deltaTime * 10f;
            yield return null;
        }
        Destroy(gameObject);
        //activate uiKey
        uIKeyFull.SetActive(true);
        //open diamondBar
        diamondBarAnimator.SetTrigger("OpenBars");

    }

}
