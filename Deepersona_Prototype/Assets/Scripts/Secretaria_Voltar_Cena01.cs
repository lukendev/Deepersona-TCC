using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secretaria_Voltar_Cena01 : MonoBehaviour
{
    
    public GameObject secretariaOpcoes;
    
    public void VoltarAndar()
    {
        Walk_by_PointClick.canMove = true;
        secretariaOpcoes.SetActive(false);
    }
}
