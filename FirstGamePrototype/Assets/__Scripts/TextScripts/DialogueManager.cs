using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogueManager : MonoBehaviour
{
    //IMPORTANT requires the TriggerZoneLevelSelection to be used with the tilemap
   
    public Text nameText;
    public Text dialogueText;
    //FIFO 
    private Queue<string> sentences;
    private Dialogue scriptDialogue;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        scriptDialogue = dialogue;

        nameText.text = dialogue.name;
        
        try
        {
            sentences.Clear();
            foreach(string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        } catch (NullReferenceException)
        {

        }
    }

    public void DisplayNextSentence()
    { 
        if(sentences.Count == 0)
        {
            ResetString();
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }


    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void ResetString()
    {
        foreach (string sentence in scriptDialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
    }


}
