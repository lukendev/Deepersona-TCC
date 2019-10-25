using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cena01_Setup : MonoBehaviour
{
    public static bool comecou;
    bool fimIvanIntro;

    public GameObject ivan;
    public GameObject startingCam;
    public GameObject levelCam;
    public GameObject dialogueBox;
    public GameObject recepcaoIntro;
    public GameObject tutorialAndar;

    void Start()
    {
        Walk_by_PointClick.canMove = false;
        ivan.GetComponent<Ivan_Scene01_Start>().ComecaDialogo();
    }

    void Update()
    {
        if(comecou && !fimIvanIntro)
        {
            fimIvanIntro = true;
            FimIvanIntro();
        }
    }

    void FimIvanIntro()
    {
        //Walk_by_PointClick.canMove = true;
        tutorialAndar.SetActive(true);
        ivan.SetActive(false);
        startingCam.SetActive(false);
        levelCam.SetActive(true);
        dialogueBox.SetActive(false);
        //recepcaoIntro.SetActive(true);
    }

}
