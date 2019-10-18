using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stress_Level : MonoBehaviour
{

    public GameObject stress1, stress2, stress3;
    public static float stress;
    public GameObject player;
    Vector3 moveDir;
    public float visionRange;
    public LayerMask OnlyPlayer;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveDir = transform.forward;
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, visionRange, OnlyPlayer))
        {
            if(hit.collider.CompareTag("Player"))
            {
                if(hit.distance < 2)
                {
                    stress1.SetActive(true);
                    stress2.SetActive(false);
                    stress3.SetActive(false);
                }
                else if(hit.distance < 5)
                {
                    stress1.SetActive(false);
                    stress2.SetActive(true);
                    stress3.SetActive(false);
                }
                else if(hit.distance < 9)
                {
                    stress1.SetActive(false);
                    stress2.SetActive(false);
                    stress3.SetActive(true);
                }
                else
                {
                    stress1.SetActive(false);
                    stress2.SetActive(false);
                    stress3.SetActive(false);
                }
            }
        }
    }
}
