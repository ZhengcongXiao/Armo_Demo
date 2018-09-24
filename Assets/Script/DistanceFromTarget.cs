using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceFromTarget : MonoBehaviour {
    public static float fromTargetDistance;
    public float toTarget;
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            toTarget = hit.distance;
            fromTargetDistance = toTarget;
        }
	}
}
