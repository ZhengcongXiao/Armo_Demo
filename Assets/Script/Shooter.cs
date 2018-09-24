using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Shooter : MonoBehaviour {
    public GameObject projectile, spwan,flash, grenadePrefab,grenadeSpawn;
    public float initialSpeed = 100.0f;
    public float throwForce = 20.0f;
    float nextFire = 0.0f;
    public float fireRate = 0.3f;
    
    public AudioClip gun;

    // Update is called once per frame
    void Update () {
        if (Armo.CurrentArmo >= 1)
        {
            if (Input.GetButton("Fire1") && Time.time>nextFire)
            {

                GameObject go;
                nextFire = Time.time + fireRate;
                go = Instantiate(projectile, spwan.transform.position, spwan.transform.rotation) as GameObject;
                flash.gameObject.SetActive(true);
                StartCoroutine("FireOff");
                go.GetComponent<Rigidbody>().velocity = transform.forward * initialSpeed;
                Destroy(go,10.0f);
                AudioSource.PlayClipAtPoint(gun, transform.position);

                Armo.CurrentArmo -= 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject grenade = Instantiate(grenadePrefab, grenadeSpawn.transform.position, grenadeSpawn.transform.rotation);
            Rigidbody rb = grenade.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
        }
	}

    IEnumerator FireOff()
    {
        yield return new WaitForSeconds(0.2f);
        flash.gameObject.SetActive(false);
    }
}
