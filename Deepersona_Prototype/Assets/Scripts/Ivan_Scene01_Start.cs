using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ivan_Scene01_Start : MonoBehaviour
{

    public GameObject dialogBox;
    void Start()
    {
    }

    public void ComecaDialogo()
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
        dialogBox.SetActive(true);
    }
}
