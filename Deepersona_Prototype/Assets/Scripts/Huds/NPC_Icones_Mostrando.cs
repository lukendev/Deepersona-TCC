using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC_Icones_Mostrando : MonoBehaviour
{

    public GameObject battleOnIcon;
    public GameObject talkOnIcon;
    public GameObject infoOnIcon;

    public GameObject battleOffIcon;
    public GameObject talkOffIcon;
    public GameObject infoOffIcon;

    public GameObject secretariaMenu;

    [SerializeField]
    public static bool onRange;

    void FixedUpdate()
    {
        Debug.Log(onRange);
    }




    private void OnMouseOver()
    {

        if(onRange)
        {
            battleOnIcon.SetActive(true);
            talkOnIcon.SetActive(true);
            infoOnIcon.SetActive(true);

            battleOffIcon.SetActive(false);
            talkOffIcon.SetActive(false);
            infoOffIcon.SetActive(false);
        }
        else
        {
            battleOnIcon.SetActive(false);
            talkOnIcon.SetActive(false);
            infoOnIcon.SetActive(false);

            battleOffIcon.SetActive(true);
            talkOffIcon.SetActive(true);
            infoOffIcon.SetActive(true);
        }
            
        
        
    }

    private void OnMouseExit()
    {
        battleOnIcon.SetActive(false);
        talkOnIcon.SetActive(false);
        infoOnIcon.SetActive(false);

        battleOffIcon.SetActive(false);
        talkOffIcon.SetActive(false);
        infoOffIcon.SetActive(false);
    }


    void OnMouseDown()
    {
        if(onRange)
        {
            secretariaMenu.SetActive(true);
            Walk_by_PointClick.canMove = false;
        }
        Walk_by_PointClick.stop = true;
    }
}
