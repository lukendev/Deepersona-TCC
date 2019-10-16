using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_to_Player : MonoBehaviour
{

    public GameObject enemyCam;
    public GameObject battleCam;
    public GameObject walkTurn;
    public GameObject moveArea;
    public GameObject player;

    // BOTOES
    public GameObject empatiaButton;
    public GameObject inteligenciaButton;
    public GameObject agressivoButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDamage()
    {
        Battle_Player.moral -= 11;
        enemyCam.SetActive(false);
        battleCam.SetActive(true);

        

        walkTurn.SetActive(true);
        Walk_by_PointClick.canMove = true;
        Start_Battle.moveRangePos = player.transform.position;
        moveArea.transform.position = player.transform.position + new Vector3(1, 0.05f, 0);

    }
}
