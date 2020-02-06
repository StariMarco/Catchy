using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class DialogueManager : MonoBehaviour {

    public HelperManager helperManager;

    private Queue<string> sentences;

    public TextMeshProUGUI dialogueText;

    public void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(List<string> dialogue)
    {
        //clear queue
        sentences.Clear();
        //load new sentences
        foreach (string sentence in dialogue)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //end dialogue
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //display sentence
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        StringBuilder stringTyper = new StringBuilder("");
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            stringTyper.Append(letter);
            dialogueText.text = stringTyper.ToString();
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void EndDialogue()
    {
        dialogueText.text = "";
        helperManager.EndDialogue();
    }
}
