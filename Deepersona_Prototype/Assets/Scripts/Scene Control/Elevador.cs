using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Elevador : MonoBehaviour
{
    // Botões ------------------------------
    public GameObject areaComunitariaButton;
    public GameObject escritorioButton;
    public GameObject voltarButton;
    // -------------------------------------

    // Condição de poder ir ao escritório
    public static bool escritorioLiberado;
    // ----------------------------------

    // Condição de poder escolher as opções dentro do elevador
    bool entered;
    // ----------------------------------

    // Player
    public GameObject player;
    // ---------------------------------
    // Ponto que o player vai virar quando entrar no elevador e ficar travado na hora de escolher as opções
    public GameObject pontoVisao;
    // -----------------------------------

    // Cameras
    public GameObject levelCam;
    public GameObject elevatorCam;
    // ----------------------------------


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !entered)
        {
            Walk_by_PointClick.canMove = false;
            entered = true;
            areaComunitariaButton.SetActive(true);
            voltarButton.SetActive(true);
            levelCam.SetActive(false);
            elevatorCam.SetActive(true);
            player.gameObject.transform.LookAt(pontoVisao.transform);
            if(escritorioLiberado)
            {
                escritorioButton.SetActive(true);
            }
            player.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            entered = false;
        }
    }

    public void DesligaBotoes()
    {
        Walk_by_PointClick.canMove = true;
        areaComunitariaButton.SetActive(false);
        voltarButton.SetActive(false);
        escritorioButton.SetActive(false);
        levelCam.SetActive(true);
        elevatorCam.SetActive(false);
        player.GetComponent<NavMeshAgent>().isStopped = false;
    }
}
