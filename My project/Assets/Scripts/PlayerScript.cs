using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private static float defaultSpeed = 2;

    public float currentSpeed = defaultSpeed;

    public float jumpMultiplier = 0.4f;

    bool isJumping = false;

    public Vector2 turn;

    Rigidbody rb;

    public GameObject camera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        rb.freezeRotation = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentSpeed *= 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            resetSpeed();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(new Vector3(0, 1, 0) * jumpMultiplier);
            isJumping = true;
            currentSpeed *= 0.25f;
        }

        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * Time.deltaTime * currentSpeed;
        }
        if (Input.GetKey("s"))
        {
            transform.position += -transform.forward * Time.deltaTime * currentSpeed;
        }
        if (Input.GetKey("d"))
        {
            transform.position += transform.right * Time.deltaTime * currentSpeed;
        }
        if (Input.GetKey("a"))
        {
            transform.position += -transform.right * Time.deltaTime * currentSpeed;
        }

        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(0, turn.x, 0); //Player "body" only rotates on the y-axis
        camera.transform.localRotation = Quaternion.Euler(-turn.y, 0, 0); //Camera "head" can rotate on x and y axis
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "Ground")
        {
            isJumping = false;
            resetSpeed();
        }
    }

    private void resetSpeed()
    {
        currentSpeed = defaultSpeed;
    }
}
