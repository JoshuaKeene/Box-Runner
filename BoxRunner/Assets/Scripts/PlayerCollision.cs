using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Rigidbody playerRB;

    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            //playerRB.useGravity = false;
            FindObjectOfType<GameManager>().LevelFailed();
        }

        if (collisionInfo.collider.tag == "Ground")
        {
            movement.hasJumped = false;
        }
    }
}
