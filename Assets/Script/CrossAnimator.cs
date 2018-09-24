using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossAnimator : MonoBehaviour {
    public GameObject up,down,left,right;
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            up.GetComponent<Animator>().enabled = true;
            down.GetComponent<Animator>().enabled = true;
            left.GetComponent<Animator>().enabled = true;
            right.GetComponent<Animator>().enabled = true;
            StartCoroutine("waitAnim");
        }
	}

    IEnumerator waitAnim()
    {
        yield return new WaitForSeconds(0.1f);
        up.GetComponent<Animator>().enabled = false;
        down.GetComponent<Animator>().enabled = false;
        left.GetComponent<Animator>().enabled = false;
        right.GetComponent<Animator>().enabled = false;
        
    }
}
