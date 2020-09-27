using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Pickup;
    public int spawnChance = 10;

    private GameObject Player;
    private float random;

    private void Awake()
    {
        Player = GameObject.Find("Player");
        random = Random.Range(1, 100);
        
        if (Player.GetComponent<PlayerMovement>().pickupActive == false)
        {
            if (random <= spawnChance)
            {
                Pickup.GetComponent<BoxCollider>().enabled = true;
                Pickup.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
