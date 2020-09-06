using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    public bool dialogueIsPlaying = false;

    private void Start()
    {
        Invoke("TriggerDialogue", 1);
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && dialogueIsPlaying)
        {
            TriggerNextSentence();
        }
    }

    public void TriggerDialogue()
    {
        dialogueIsPlaying = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    public void TriggerNextSentence()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
}

