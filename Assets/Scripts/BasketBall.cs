using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBall : MonoBehaviour
{
    [SerializeField] private float throwForce;
    private Rigidbody rb;
    [SerializeField] private Transform resetPosition;
    private GameObject player;

    /// <summary>
    /// Determines whether player can throw ball
    /// </summary>
    private bool holdingBall = true;

    [SerializeField]
    private Light spotlight;

    void Start()
    {
        player = this.gameObject.transform.root.gameObject;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }

    }
    void FixedUpdate()
    {
        // Only launch the ball if we're holding it
        if (holdingBall && Input.GetKeyDown(KeyCode.Space))
        {
            Launch();

            // No longer holding ball
            holdingBall = false;
        }

        // Make spotlight follow ball
        spotlight.transform.position = new Vector3(transform.position.x, spotlight.transform.position.y, transform.position.z);
    }

    // I don't know why it doesn't reset to the starting position 
    private void Reset()
    {
        this.transform.position = resetPosition.position;
        rb.isKinematic = true;
        this.transform.parent = player.transform;

        // Holding ball again, so we can throw it
        holdingBall = true;
    }

    private void Launch() {
        rb.isKinematic = false;
        this.transform.parent = null;
        rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
        rb.AddForce(transform.up * throwForce, ForceMode.Impulse);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball Respawn")) {
            Reset();
            player.GetComponent<Player>().Reset();
        }
    }
}
