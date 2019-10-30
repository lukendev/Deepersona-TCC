using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamArea_Control : MonoBehaviour
{

    // CAMERAS DO LEVEL
    public GameObject cam01;
    public GameObject cam02;
    // -----------------

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            cam01.SetActive(true);
            cam02.SetActive(false);
        }
    }
}
