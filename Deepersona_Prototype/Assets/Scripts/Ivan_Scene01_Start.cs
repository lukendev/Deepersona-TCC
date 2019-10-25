using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ivan_Scene01_Start : MonoBehaviour
{
    void Start()
    {
    }

    public void ComecaDialogo()
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
