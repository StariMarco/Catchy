using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelperManager : MonoBehaviour
{
    public Animator animator;
    public SpaceIconManager spaceIcon;

    private bool dialogueStarted = false;
    [TextArea(3, 10)]
    public List<string> dialogue = new List<string>();

    private PlayerController player;

    private bool canClick = true;
    public float clickDelay;

    public bool hasDialogued = false;
    public TextMeshProUGUI dialogueText;

    private void Start()
    {
        player = GameObject.Find("Body").GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //activate spaceIcon
            spaceIcon.Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //deactivate spaceIcon
            spaceIcon.Deactivate();
        }
    }

    private void Update()
    {
        if (spaceIcon.activated && Input.GetKeyDown(KeyCode.Space) && canClick)
        {
            canClick = false;
            StartCoroutine(EnableClick());

            //Play sound
            FindObjectOfType<AudioManager>().PlaySound("NextSentence");

            if (!dialogueStarted)
                StartCoroutine(StartDialogue());
            else
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }

    private IEnumerator EnableClick()
    {
        yield return new WaitForSeconds(clickDelay);
        canClick = true;
    }

    private IEnumerator StartDialogue()
    {
        //open the dialogue bg
        animator.SetBool("Activated", true);
        dialogueStarted = true;
        hasDialogued = true;
        //deactivate player movements
        player.canMove = false;
        //deactivate space icon
        spaceIcon.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        //start dialogue
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void EndDialogue()
    {
        //close the dialogue bg
        animator.SetBool("Activated", false);
        dialogueStarted = false;
        //reactivate player movements
        player.canMove = true;
        //dialogue text 
        dialogueText.text = " ";
        //reactivate space icon
        spaceIcon.gameObject.SetActive(true);
    }

    public void SetDialogue(List<string> newDialogue)
    {
        this.dialogue = newDialogue;
    }

    public void DeactivateHelper()
    {
        gameObject.SetActive(false);
    }

}
