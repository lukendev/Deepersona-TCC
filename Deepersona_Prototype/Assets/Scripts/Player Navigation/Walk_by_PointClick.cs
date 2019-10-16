using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Walk_by_PointClick : MonoBehaviour
{
    /* Variaveis do mecanismo de andar com Pointn Click */
    public Camera cam;

    public NavMeshAgent agent;

    public ThirdPersonCharacter character;
    /* ------------------------------------------------ */

    public static bool canMove;
    public static bool stop;

    public static bool onBattle;
    public float maxDistance;


    void Start()
    {
        agent.updateRotation = false;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;


                if (Physics.Raycast(ray, out hit))
                {
                    if(onBattle)
                    {
                        Vector3 mag = Start_Battle.moveRangePos - hit.point;
                        if(mag.magnitude < maxDistance)
                        {
                            agent.SetDestination(hit.point);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        // MOVE OUR AGENT
                        agent.SetDestination(hit.point);
                    }
                }
            }
        }
        

        if(agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        } else
        {
            character.Move(Vector3.zero, false, false);
        }

        if(stop)
        {
            stop = false;
            Stop();
        }

    }

    void Stop()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }
}

