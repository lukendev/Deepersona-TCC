using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamArea_Control2 : MonoBehaviour
{
    // CAMERAS DO LEVEL
    public GameObject cam01;
    public GameObject cam02;
    // -----------------

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            cam02.SetActive(true);
            cam01.SetActive(false);
        }
    }
}
