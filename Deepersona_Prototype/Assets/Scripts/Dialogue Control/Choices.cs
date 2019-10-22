using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Choices
{
    public string[] possbileAnswers;

    [TextArea(3, 10)]
    public string[] feedback1;
    [TextArea(3, 10)]
    public string[] feedback2;
    [TextArea(3, 10)]
    public string[] feedback3;
    private bool done;
}
