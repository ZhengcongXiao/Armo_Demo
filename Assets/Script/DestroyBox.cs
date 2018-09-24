using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox : MonoBehaviour {
    public GameObject destroyVersion;

    public void DesBox()
    {
        Instantiate(destroyVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
