using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class BulletCollision : MonoBehaviour {
    public GameObject bullet;
    public GameObject explosionPrefab;
    //public GameObject health;
    public AudioClip clip;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy" || collision.gameObject.tag == "monst")
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            GameObject explosion = Instantiate(explosionPrefab,pos,rot) as GameObject;

            Destroy(explosion,3.0f);
            Destroy(collision.gameObject);
            Destroy(bullet);
            AudioSource.PlayClipAtPoint(clip,transform.position);
        }

        if (collision.gameObject.tag == "Player")
        {
            Health.currentHealth -= 10f;
            //Debug.Log(Health.currentHealth);
            Destroy(bullet);
        }

    }
}
