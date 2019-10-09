using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_AnswerStarter : MonoBehaviour
{

    public GameObject answer1;
    public GameObject answer2;
    public GameObject answer3;

    public GameObject enemyMoral;

    public GameObject button;


    public GameObject player;
    public GameObject enemy;

    

    public void StartAnswers()
    {
        Walk_by_PointClick.canMove = false;
        player.transform.LookAt(enemy.transform);
        enemy.transform.LookAt(player.transform);


        answer1.SetActive(true);
        answer2.SetActive(true);
        answer3.SetActive(true);
        button.SetActive(false);
        enemyMoral.SetActive(true);
    }
}
