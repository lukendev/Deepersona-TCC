using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Andar : MonoBehaviour
{
    public GameObject recepcaoIntro;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PodeAndar();
            StartCoroutine (AcabaTutorial());
        }
    }

    IEnumerator AcabaTutorial()
    {
        yield return new WaitForSeconds(3);
        recepcaoIntro.SetActive(true);
        gameObject.SetActive(false);
    }

    void PodeAndar()
    {
        Walk_by_PointClick.canMove = true;
    }
}
