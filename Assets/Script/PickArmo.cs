using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickArmo : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && Armo.CurrentArmo > 0)
        {
            Armo.ReloadArmo += 10;
            this.gameObject.SetActive(false);
        }
        if (collider.gameObject.tag == "Player" && Armo.CurrentArmo == 0)
        {
            Armo.CurrentArmo += 10;
            this.gameObject.SetActive(false);
        }
    }
}
