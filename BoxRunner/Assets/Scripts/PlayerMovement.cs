using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRB;
    public float forwardForce = 4000f;
    public float horizontalForce = 500f;
    public float jumpForce = 100f;
    public bool hasJumped = true;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        playerRB.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            playerRB.AddForce(horizontalForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            playerRB.AddForce(-horizontalForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("space") && hasJumped == false)
        {
            playerRB.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
            hasJumped = true;
            Debug.Log("SPACE");
        }

        if (playerRB.position.y < -1f)
        {
            FindObjectOfType<GameManager>().LevelFailed();
        }

    }
}
