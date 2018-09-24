using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Reload : MonoBehaviour {
    public GameObject cross,gun;
    int clipCount;
    int ReserveCount;
    int reloadAvailable;
    public AudioClip loadingSound;

    // Update is called once per frame
    void Update () {
        //clipCount = Armo.ReloadArmo;
        //ReserveCount = Armo.CurrentArmo;
        ReserveCount = Armo.ReloadArmo;
        clipCount = Armo.CurrentArmo;

        if (ReserveCount == 0)
        {
            reloadAvailable = 0;
        }
        else
        {
            reloadAvailable = 10 - clipCount;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (reloadAvailable >= 1)
            {
                if (ReserveCount <= reloadAvailable)
                {
                    Armo.CurrentArmo += ReserveCount;
                    Armo.ReloadArmo -= ReserveCount;
                    StartCoroutine("ActionReload");
                }
                else
                {
                    Armo.CurrentArmo += reloadAvailable;
                    Armo.ReloadArmo -= reloadAvailable;
                    StartCoroutine("ActionReload");
                }
            }
            StartCoroutine("EnableScript");
        }
    }

    IEnumerator EnableScript()
    {
        yield return new WaitForSeconds(1.1f);
        this.GetComponent<Shooter>().enabled = true;
        //machanic.SetActive(true);
        cross.SetActive(true);
    }
    IEnumerator ActionReload()
    {
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<Shooter>().enabled = false;
        //machanic.SetActive(false);
        cross.SetActive(false);
        AudioSource.PlayClipAtPoint(loadingSound, transform.position);
        //gun.GetComponentInChildren<Animator>().enabled = true;
        //yield return new WaitForSeconds(1.0f);
        //gun.GetComponentInChildren<Animator>().enabled = false;
        if (gameObject.tag == "pistal")
        {
            gun.GetComponent<Animation>().Play("Gun");
        }
        
    }
}
