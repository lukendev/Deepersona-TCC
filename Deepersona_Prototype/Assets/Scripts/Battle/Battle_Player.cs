using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_Player : MonoBehaviour
{
    public GameObject levelManager;
    public Slider currentMoral;
    public Slider playerMoral;
    public static float moral;
    public float baseDamage;
    public int currentAnxiety;

    public Animator anim;

    // Cameras
    public GameObject battleCam;
    public GameObject playerActionCam;

    public GameObject enemy;

    //BOTÕES DE COMBATE
    public GameObject empatiaButton;
    public GameObject inteligenciaButton;
    public GameObject agressivoButton;

    void Start()
    {
        moral = 33;
        playerMoral.maxValue = 33;
        playerMoral.value = 33;
    }

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

        StartCoroutine(TempoDeEspera());

        empatiaButton.SetActive(false);
        inteligenciaButton.SetActive(false);
        agressivoButton.SetActive(false);
    }

    public IEnumerator TempoDeEspera()
    {

        yield return new WaitForSeconds(2);
        enemy.GetComponent<AI_Patrulha>().IniciarTurno();
    }


    // Update is called once per frame
    void Update()
    {
        currentMoral.value = moral;

        if (moral <= 0)
        {
            levelManager.GetComponent<MySceneManager>().Reload();
        }
    }
}
