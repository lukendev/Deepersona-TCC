using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(playerPoint);
        moveDir = transform.forward;
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, 10, OnlyPlayer))
        {
            if(hit.collider.CompareTag("Player") && !battleStarted)
            {
                Walk_by_PointClick.stop = true;
                battleFeedback.SetActive(true);
                battleStarted = true;
                Walk_by_PointClick.canMove = false;

                // Camera
                levelCam.SetActive(false);
                battleCam.SetActive(true);
            }
        } else 
                battleFeedback.SetActive(false);

    }

}
