using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            TriggerDialogue();
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            TriggerNextSentence();
        }


    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    public void TriggerNextSentence()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
}

