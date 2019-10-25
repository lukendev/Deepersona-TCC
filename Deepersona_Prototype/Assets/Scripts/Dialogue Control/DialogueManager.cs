using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	private Queue<string> sentences;
    public Button[] answers;
    public Button continueButton;

    public bool isThereChoice;
    public GameObject currentDialogue;
    public Choices choosers;


	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();

        foreach (Button but in answers)
        {
            but.GetComponentInChildren<Text>().text = "";
            but.gameObject.SetActive(false);
        }
	}

	public void StartDialogue (Dialogue dialogue)
	{
        foreach (Button but in answers)
        {
            but.gameObject.SetActive(false);
        }

        continueButton.gameObject.SetActive(true);

        animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

    public void setAnswers(Choices choices)
    {
        for(int i = 0; i <= answers.Length-1; i++)
        {
            answers[i].GetComponentInChildren<Text>().text = choices.possbileAnswers[i];
        }
    }

    public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
            if (isThereChoice)
            {
                foreach (Button but in answers)
                {
                    but.gameObject.SetActive(true);
                }

                continueButton.gameObject.SetActive(false);
                isThereChoice = false;

                return;
            }

			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	public void EndDialogue()
	{
		animator.SetBool("IsOpen", false);

        // LUCAS: mudando aqui porque nesse caso vai ser a primeira fala. Verificar script Cena01_Setup.
        if(!Cena01_Setup.comecou)
        {
            Cena01_Setup.comecou = true;
        }
        // ----------------
	}

    private void quickFix()
    {
        foreach (Button but in answers)
        {
            but.gameObject.SetActive(false);
        }

        continueButton.gameObject.SetActive(true);
    }

    public void StartFeedback1()
    {
        Choices choices;
        choices = choosers;
        currentDialogue.gameObject.GetComponent<DialogueTrigger>().dontChange = 1;
        currentDialogue.gameObject.GetComponent<DialogueTrigger>().isThereChoice = false;
        quickFix();
        sentences.Clear();

        foreach (string sentence in choices.feedback1)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void StartFeedback2()
    {
        Choices choices;
        choices = choosers;
        currentDialogue.gameObject.GetComponent<DialogueTrigger>().dontChange = 2;
        currentDialogue.gameObject.GetComponent<DialogueTrigger>().isThereChoice = false;
        quickFix();
        sentences.Clear();

        foreach (string sentence in choices.feedback2)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void StartFeedback3()
    {
        Choices choices;
        choices = choosers;
        currentDialogue.gameObject.GetComponent<DialogueTrigger>().dontChange = 3;
        currentDialogue.gameObject.GetComponent<DialogueTrigger>().isThereChoice = false;
        quickFix();
        sentences.Clear();


        foreach (string sentence in choices.feedback3)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

}
