using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_to_Player : MonoBehaviour
{

    public GameObject enemyCam;
    public GameObject battleCam;

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
    }
}
