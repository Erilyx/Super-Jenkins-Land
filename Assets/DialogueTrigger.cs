using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            TriggerDialogue();
        }

        if(Input.GetKeyDown(KeyCode.Z))
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

