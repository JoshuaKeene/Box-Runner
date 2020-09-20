﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    public float restartDelay = 5f;
    public GameObject levelFailedUI;

    public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GameOver");
            Invoke("Restart", restartDelay);
        }
    }

    public void LevelFailed ()
    {
        levelFailedUI.SetActive(true);
        Debug.Log("LEVELFAILED");
        Invoke("Restart", restartDelay);
    }

    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}