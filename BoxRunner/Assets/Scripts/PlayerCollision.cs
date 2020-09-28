using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Rigidbody playerRB;
    public AudioSource CanvasAudio;

    private void Awake()
    {
        StartCoroutine(AudioManager.GlobalSFXManager.FadeIn(CanvasAudio, 2));
    }

    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            //playerRB.useGravity = false;
            StartCoroutine(AudioManager.GlobalSFXManager.FadeOut(CanvasAudio, 1));
            playerRB.gameObject.GetComponent<AudioSource>().PlayOneShot(AudioManager.GlobalSFXManager.GameOver);
            FindObjectOfType<GameManager>().LevelFailed();
        }

        if (collisionInfo.collider.tag == "Ground")
        {
            movement.hasJumped = false;
        }
    }
}
