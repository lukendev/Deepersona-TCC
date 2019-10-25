using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy01 : MonoBehaviour
{
    public Slider currentMoral;
    public static float moral = 66;
    public float baseDamage;
    public int type;
    // Types: 1 = Hostil; 2 = Inteligência; 3 = Carismático

    public static bool startBattle;

    void FixedUpdate()
    {
        if(startBattle)
        {
            startBattle = false;
            Battle_Set();
        }
        
        currentMoral.value = moral;

        if(moral <= 0)
        {
            
        }

        if (moral <= 0)
        {
            gameObject.GetComponent<AI_Patrulha>().Perder();
            //Walk_by_PointClick.canMove = true;
            Walk_by_PointClick.onBattle = false;
        }
    }

    public void Battle_Set()
    {
        currentMoral.maxValue = 66;
    }

    public static void Damage(float baseValue, int attackType)
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
            moral -= (baseValue*4f);
        }

    }


}
