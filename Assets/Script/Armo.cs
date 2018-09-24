using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armo : MonoBehaviour {
    public static int CurrentArmo;
    int internalArmo;
    public GameObject armoDisplay;

    public static int ReloadArmo = 0;
    int internalReload;
    public GameObject loadDisplay;

    // Update is called once per frame
    void Update () {
        internalArmo = CurrentArmo;
        internalReload = ReloadArmo;
        armoDisplay.GetComponent<Text>().text = "" + internalArmo;
        loadDisplay.GetComponent<Text>().text = "" + internalReload;
    }
}
