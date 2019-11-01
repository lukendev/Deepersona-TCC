using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secretaria_Info_Cena01 : MonoBehaviour
{

    public GameObject infos;
    public GameObject secretariaOpcoes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MostraInfos()
    {
        secretariaOpcoes.SetActive(false);
        infos.SetActive(true);
    }

    public void FechaInfos()
    {
        secretariaOpcoes.SetActive(true);
        infos.SetActive(false);
    }
}
