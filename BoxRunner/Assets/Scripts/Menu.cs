using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Credits;
    
    public void OnClickStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.visible = false;
    }

    public void OnClickCredits()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
    }

    public void OnClickBack()
    {
        MainMenu.SetActive(true);
        Credits.SetActive(false);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
