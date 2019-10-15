using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour {

    private float localposition;
    public float speed;
    public float aceleration;

	// Use this for initialization
	void Start () {
        localposition = gameObject.transform.position.y;
        gameObject.transform.position = new Vector3 (gameObject.transform.position.x, -1000, gameObject.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.y <= localposition)
        gameObject.transform.position += new Vector3(0, speed * aceleration, 0);
	}
}
