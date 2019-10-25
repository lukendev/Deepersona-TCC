using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Icons_Range : MonoBehaviour
{

    public Transform playerPoint;
    public LayerMask OnlyPlayer;
    public Vector3 moveDir;
    public float visionRange;


    void FixedUpdate()
    {
        transform.LookAt(playerPoint);
        moveDir = transform.forward;
        RaycastHit hit;

        Debug.DrawRay(transform.position, moveDir, Color.green);

        if(Physics.Raycast(transform.position, transform.forward, out hit, visionRange, OnlyPlayer))
        {
            NPC_Icones_Mostrando.onRange = true;
        }
        else
        {
            NPC_Icones_Mostrando.onRange = false;
        }
    }
}
