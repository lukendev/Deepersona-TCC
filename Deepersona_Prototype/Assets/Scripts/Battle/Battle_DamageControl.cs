using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_DamageControl : MonoBehaviour
{
    public Slider currentEnemyMoral;
    public void Moral_Changed(float newValue)
    {
        currentEnemyMoral.value -= newValue;
    }


}
