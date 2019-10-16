using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Battle_AnswerStarter : MonoBehaviour
{

    public GameObject answer1;
    public GameObject answer2;
    public GameObject answer3;

    public GameObject enemyMoral;

    public GameObject button;


    public GameObject player;
    public GameObject enemy;

    public NavMeshAgent agent;

    

    public void StartAnswers()
    {
        Walk_by_PointClick.canMove = false;
        player.transform.LookAt(enemy.transform);
        enemy.transform.LookAt(player.transform);

        agent.isStopped = true;
        agent.ResetPath();


        answer1.SetActive(true);
        answer2.SetActive(true);
        answer3.SetActive(true);
        button.SetActive(false);
        enemyMoral.SetActive(true);
    }
}
