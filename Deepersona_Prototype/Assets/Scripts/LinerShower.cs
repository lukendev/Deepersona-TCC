using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinerShower : MonoBehaviour
{

    public Outline outliner;
    // Use this for initialization
    void Start()
    {
        outliner = gameObject.GetComponent<Outline>();
        outliner.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        outliner.enabled = true;
    }

    private void OnMouseExit()
    {
        outliner.enabled = false;
    }
}
