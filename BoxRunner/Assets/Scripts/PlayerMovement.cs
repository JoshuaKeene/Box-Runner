using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRB;
    public float forwardForce = 4000f;
    public float horizontalForce = 500f;
    public float jumpForce = 100f;
    public bool hasJumped = true;
    public float regularForce = 4000f;
    public float slowedForce = 2000f;

    public Material PlayerColour;
    public Material ObstacleColour;
    public Material SlowedColour;

    public bool pickupActive = false;

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

        if (playerRB.position.y < -1f)
        {
            FindObjectOfType<GameManager>().LevelFailed();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SlowSpeed")
        {
            pickupActive = true;
            
            Destroy(other.gameObject);
            gameObject.GetComponent<MeshRenderer>().material = SlowedColour;
            forwardForce = slowedForce;
            Invoke("restoreSpeed", 5);
        }

        if (other.tag == "PhaseThrough")
        {
            pickupActive = true;

            Destroy(other.gameObject);
            gameObject.GetComponent<MeshRenderer>().material = ObstacleColour;
            gameObject.layer = 10;
            Invoke("restoreLayer", 5);
        }
    }

    private void restoreSpeed()
    {
        pickupActive = false;

        forwardForce = regularForce;
        gameObject.GetComponent<MeshRenderer>().material = PlayerColour;
    }

    private void restoreLayer()
    {
        pickupActive = false;

        gameObject.layer = 0;
        gameObject.GetComponent<MeshRenderer>().material = PlayerColour;
    }
}
