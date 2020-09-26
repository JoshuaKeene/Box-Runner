using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinteGeneration : MonoBehaviour
{
    private Vector3 thisPos;
    private Vector3 spawnPos;

    private bool Entered = false;
    
    // Start is called before the first frame update
    void Start()
    {
        thisPos = gameObject.transform.position;
        spawnPos = new Vector3(thisPos.x, thisPos.y, thisPos.z + 50);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" && !Entered)
        {
            Entered = true;
            
            int randomGroundType = Random.Range(0, ObstacleManager.obstacles.groundTypes.Length);
            Instantiate(ObstacleManager.obstacles.groundTypes[randomGroundType], spawnPos, gameObject.transform.rotation);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject, 3);
            foreach (Transform child in transform.parent)
            {
                GameObject.Destroy(child.gameObject, 3);
            }
        }
    }
}
