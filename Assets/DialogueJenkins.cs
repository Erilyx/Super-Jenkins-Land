using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueJenkins : MonoBehaviour
{

    public Rigidbody2D jenkinsRB;
    public DialogueTrigger triggerDialogue;
    public bool dialogueIsPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        jenkinsRB = GetComponent<Rigidbody2D>();
        Invoke("JenkinsEntrance", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && dialogueIsPlaying)
        {
            triggerDialogue.TriggerNextSentence();
        }
    }

    public void JenkinsEntrance()
    {
        dialogueIsPlaying = true;
        jenkinsRB.velocity = new Vector2(5, 10);
        Invoke("StartDialogue", 2.3f);

    }
    public void StartDialogue()
    {
        triggerDialogue.TriggerDialogue();
    }
}
