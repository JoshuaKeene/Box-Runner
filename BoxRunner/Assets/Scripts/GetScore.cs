using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    public Transform player;
    public Text scoreText;

    private void Awake()
    {
        scoreText.text = player.position.z.ToString("0");
    }
}
