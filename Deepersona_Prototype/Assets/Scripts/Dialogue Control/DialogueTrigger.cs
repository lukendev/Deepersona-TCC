using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    public bool isThereChoice;
    public bool isThereBattle;
    public Choices choices;
    public int dontChange = 0; 



    public void TriggerDialogue ()
	{
        if (dontChange==0)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            if (isThereChoice)
            {
                FindObjectOfType<DialogueManager>().currentDialogue = gameObject;
                FindObjectOfType<DialogueManager>().setAnswers(choices);
                FindObjectOfType<DialogueManager>().choosers = choices;
                FindObjectOfType<DialogueManager>().isThereChoice = true;
            }
        }

        if (dontChange == 1)
        {
            FindObjectOfType<DialogueManager>().currentDialogue = gameObject;
            FindObjectOfType<DialogueManager>().StartFeedback1();
        }

        if (dontChange == 2)
        {
            FindObjectOfType<DialogueManager>().currentDialogue = gameObject;
            FindObjectOfType<DialogueManager>().StartFeedback2();
        }

        if (dontChange == 3)
        {
            FindObjectOfType<DialogueManager>().currentDialogue = gameObject;
            FindObjectOfType<DialogueManager>().StartFeedback3();
        }
    }

    public void OnTriggerEnter(Collider col)
    {

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

        if (isThereBattle)
        {
            FindObjectOfType<DialogueManager>().isBattleManager = true;
        }

        if (isThereChoice)
        {
            FindObjectOfType<DialogueManager>().currentDialogue = gameObject;
            FindObjectOfType<DialogueManager>().setAnswers(choices);
            FindObjectOfType<DialogueManager>().choosers = choices;
            FindObjectOfType<DialogueManager>().isThereChoice = true;
        }

        if (dontChange == 1)
        {
            FindObjectOfType<DialogueManager>().currentDialogue = gameObject;
            FindObjectOfType<DialogueManager>().StartFeedback1();
        }

        if (dontChange == 2)
        {
            FindObjectOfType<DialogueManager>().currentDialogue = gameObject;
            FindObjectOfType<DialogueManager>().StartFeedback2();
        }

        if (dontChange == 3)
        {
            FindObjectOfType<DialogueManager>().currentDialogue = gameObject;
            FindObjectOfType<DialogueManager>().StartFeedback3();
        }

    }

    public void OnTriggerExit(Collider col)
    {

        FindObjectOfType<DialogueManager>().EndDialogue();
        if (isThereChoice)
        {
            FindObjectOfType<DialogueManager>().isThereChoice = false;
        }

    }

}
