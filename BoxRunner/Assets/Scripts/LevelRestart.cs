using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestart : MonoBehaviour
{
   public void RestartLevel ()
    {
        FindObjectOfType<GameManager>().Restart();
    }
}
