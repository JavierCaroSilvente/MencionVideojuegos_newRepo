using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPosibleShot : MonoBehaviour
{
    public GameObject SpaceShipScript;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Torpedo")
        {
            SpaceShipScript.GetComponent<SpaceShipScript>().totalBulletsInScene = 0;
        }
    }
}
