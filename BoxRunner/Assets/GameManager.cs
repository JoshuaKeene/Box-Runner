using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    public float restartDelay = 5f;
    public GameObject UI_LevelFailed;

    private void Update()
    {
        if (UI_LevelFailed.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (UI_LevelFailed.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.visible = false;
            Restart();
        }
    }

    public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GameOver");
            //Invoke("Restart", restartDelay);
        }
    }

    public void LevelFailed ()
    {
        UI_LevelFailed.SetActive(true);
        Cursor.visible = true;
        Debug.Log("LEVELFAILED");
        //Invoke("Restart", restartDelay);
    }

    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
