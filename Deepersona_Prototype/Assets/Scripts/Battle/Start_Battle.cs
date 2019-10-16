using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Start_Battle : MonoBehaviour
{

    /* Variaveis para feedback para o programador (temporário) */
    public GameObject battleFeedback;
    /* --------------------------------- */


    /* Variaveis do mecanismo do raycast */
    public Transform playerPoint;
    public LayerMask OnlyPlayer;
    public Vector3 moveDir;
    /* ---------------------------------- */


    /* Variaveis do controle de acontecimentos */
    public GameObject levelCam;
    public GameObject battleCam;
    bool battleStarted;
    /* ----------------------------------- */

    public GameObject moveRange;
    public GameObject player;
    public GameObject enemy;
    public static Vector3 moveRangePos;

    public GameObject navOne;

    public NavMeshSurface navMoveRange;
    public float visionRange;

    public GameObject moveArea;

    [SerializeField]
    float dist;

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(playerPoint);
        moveDir = transform.forward;
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, visionRange, OnlyPlayer))
        {
            if(hit.collider.CompareTag("Player") && !battleStarted)
            {
                Enemy01.startBattle = true;
                Walk_by_PointClick.stop = true;
                battleFeedback.SetActive(true);
                battleStarted = true;
                //Walk_by_PointClick.canMove = false;

                enemy.GetComponent<AI_Patrulha>().IniciarCombate();

                moveRangePos = player.transform.position;
                moveArea.transform.position = moveRangePos + new Vector3(1, 0.05f, 0);
                moveArea.SetActive(true);
                //moveRange.transform.position = moveRangePos;

                //navOne.SetActive(false);

                // Camera
                levelCam.SetActive(false);
                battleCam.SetActive(true);

                Walk_by_PointClick.onBattle = true;
            }
            else
            {
                dist = hit.distance;
            }
        }

    }

}
