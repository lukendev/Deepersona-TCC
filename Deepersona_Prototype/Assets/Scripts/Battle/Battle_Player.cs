using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_Player : MonoBehaviour
{

    public Slider currentMoral;
    public float moral;
    public float baseDamage;
    public int currentAnxiety;

    public Animator anim;

    // Cameras
    public GameObject battleCam;
    public GameObject playerActionCam;

    public GameObject enemy;


    public void Battle_Set()
    {
        currentMoral.maxValue = 33;
        currentMoral.value = moral;
    }

    public void Damage(float baseValue, int attackType)
    {
        if(currentAnxiety == 1) // Hostil
        {
            if(attackType == 1)
            {
                moral -= (baseValue*.66f);
            }
            else if(attackType == 2) 
            {
                moral -= baseValue;
            }
            else if(attackType == 3) 
            {
                moral -= (baseValue*1.33f);
            }
        } 
        else if(currentAnxiety == 2) // Inteligencia
        {
            if(attackType == 1)
            {
                moral -= (baseValue*1.33f);
            }
            else if(attackType == 2)
            {
                moral -= (baseValue*.66f);
            }
            else if(attackType == 3)
            {
                moral -= baseValue;
            }        
        }
        else if(currentAnxiety == 3) // Carismatica
        {
            if(attackType == 1)
            {
                moral -= baseValue;
            }
            else if(attackType == 2)
            {
                moral -= (baseValue*1.33f);
            }
            else if(attackType == 3)
            {
                moral -= (baseValue*.66f);
            }
        }

        currentMoral.value = moral;
    }

    public void Start_Attack(int attackType)
    {
        if(attackType == 3)
        {
            anim.SetTrigger("Carisma");
        }
        else if(attackType == 2)
        {
            anim.SetTrigger("Inteligencia");
        }
        else if(attackType == 1)
        {
            anim.SetTrigger("Agressiva");
        }

        battleCam.SetActive(false);
        playerActionCam.SetActive(true);
    }
    public void Give_Damage(int attackType)
    {
        battleCam.SetActive(true);
        playerActionCam.SetActive(false);

        Enemy01.Damage(baseDamage, attackType);

        enemy.GetComponent<AI_Patrulha>().IniciarTurno();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
