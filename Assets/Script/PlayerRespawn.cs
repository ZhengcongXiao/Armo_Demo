using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {
    public GameObject player;

    private void Update()
    {
        if(Health.currentHealth == 0.0f)
        {
            player.transform.position = new Vector3(Random.Range(20.0f,-20.0f), 0, Random.Range(20.0f,-20.0f));
            Health.currentHealth = 100.0f;
        }
    }
}
