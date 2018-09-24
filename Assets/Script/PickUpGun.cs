using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpGun : MonoBehaviour {
    public GameObject textDes;
    public GameObject Gun;
    public GameObject playerGun;
    public GameObject pistal;
    float theDistance = DistanceFromTarget.fromTargetDistance;
	
	// Update is called once per frame
	void Update () {
		theDistance = DistanceFromTarget.fromTargetDistance;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Gun.SetActive(false);
            playerGun.SetActive(true);
            pistal.SetActive(false);
            textDes.GetComponent<Text>().text = "";
        }
    }

    private void OnMouseOver()
    {
        if (theDistance <= 5)
        {
            textDes.GetComponent<Text>().text = "Press F";
        }
    }

    private void OnMouseExit()
    {
        textDes.GetComponent<Text>().text = "";
    }
}
