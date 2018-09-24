using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
    public float delay = 3.0f;
    public float radius = 5.0f;
    public float force = 700.0f;

    public GameObject explosionPrefab;

    float countdown;
    bool hasExploded = false;
	// Use this for initialization
	void Start () {
        countdown = delay;
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && hasExploded == false)
        {
            Explode();
            hasExploded = true;
        }
	}

    void Explode()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObject in colliders)
        {
            DestroyBox dest = nearbyObject.GetComponent<DestroyBox>();
            if (dest != null)
            {
                dest.DesBox();
            }
        }

        Collider[] moveColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in moveColliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(gameObject);
    }
}
