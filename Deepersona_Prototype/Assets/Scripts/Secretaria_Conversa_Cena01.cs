using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secretaria_Conversa_Cena01 : MonoBehaviour
{

    public static bool conversou;
    public static bool recomeca;
    public GameObject botoes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(recomeca)
        {
            recomeca = false;
            RecomecarOpcoes();
        }
    }

    public void Conversa()
    {
        conversou = true;
        botoes.SetActive(false);
    }

    public void RecomecarOpcoes()
    {
        botoes.SetActive(true);
    }
}
