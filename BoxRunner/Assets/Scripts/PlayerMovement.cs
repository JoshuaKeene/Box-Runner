using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public float timeLeft = 10;
    public Text pickupTimer;

    float currCountdownValue;

    public bool pickupActive = false;
    public bool timeReset = true;

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

        if (playerRB.position.x < -11f || playerRB.position.x > 11f)
        {
            FindObjectOfType<GameManager>().LevelFailed();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SlowSpeed")
        { 
            Destroy(other.gameObject);

            if (!pickupActive)
            {
                pickupActive = true;
                gameObject.GetComponent<MeshRenderer>().material = SlowedColour;
                forwardForce = slowedForce;
                pickupTimer.gameObject.SetActive(true);
                StartCoroutine("StartCountdown", 5);
                Invoke("restoreSpeed", 5);
            }
        }

        if (other.tag == "PhaseThrough")
        {
            Destroy(other.gameObject);

            if (!pickupActive)
            {
                pickupActive = true;
                gameObject.GetComponent<MeshRenderer>().material = ObstacleColour;
                gameObject.layer = 10;
                pickupTimer.gameObject.SetActive(true);
                StartCoroutine("StartCountdown", 5);
                Invoke("restoreLayer", 5);
            }
        }
    }

    private void restoreSpeed()
    {
        pickupActive = false;
        pickupTimer.gameObject.SetActive(false);

        forwardForce = regularForce;
        gameObject.GetComponent<MeshRenderer>().material = PlayerColour;
    }

    private void restoreLayer()
    {
        pickupActive = false;
        pickupTimer.gameObject.SetActive(false);

        gameObject.layer = 0;
        gameObject.GetComponent<MeshRenderer>().material = PlayerColour;
    }

    public IEnumerator StartCountdown(float countdownValue)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            pickupTimer.text = currCountdownValue.ToString();

            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;

            
        }
    }
}
