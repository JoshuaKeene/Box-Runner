using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager obstacles;

    public GameObject[] groundTypes;

    // Start is called before the first frame update
    void Start()
    {
        obstacles = this;
    }
}
