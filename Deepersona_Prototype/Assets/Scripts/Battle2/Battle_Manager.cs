using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Manager : MonoBehaviour
{
    // ENEMY HUDS --------------------
    public GameObject enemyMoral;
    // -------------------------------

    // PLAYER HUDS --------------------
    public GameObject playerMoral;
    public GameObject playerAttacksHud;
    // --------------------------------


    public void StartBattle()
    {
        Debug.Log("Batalha Começou");
        // TRAVA PLAYER -------------------
        Walk_by_PointClick.canMove = false;
        // --------------------------------

        // MOSTRA HUDS -------------------
        playerMoral.SetActive(true);
        enemyMoral.SetActive(true);
        playerAttacksHud.SetActive(true);
        // -------------------------------
    }
}
