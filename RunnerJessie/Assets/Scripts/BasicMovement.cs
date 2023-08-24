using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    public Rigidbody rb;
    public bool isGrounded = false;
    public bool isJumping = false;
    public bool isFalling = false;
    public bool isMovingLeft = false;
    public bool isMovingRight = false;
    public bool isMovingForward = false;

    public float laneDistance = 4f;

    public Vector3 desiredPosition;

    public float horizontalSpeed = 5f;

    public Animator anim;

    public Score score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        desiredPosition = transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //move forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //move left
        if (Input.GetKeyDown(KeyCode.A) && !isMovingLeft)
        {
            desiredPosition += Vector3.left * laneDistance;
            isMovingLeft = true;
            isMovingRight = false;
            isMovingForward = false;
        }

        //move right
        if (Input.GetKeyDown(KeyCode.D) && !isMovingRight)
        {
            desiredPosition += Vector3.right * laneDistance;
            isMovingRight = true;
            isMovingLeft = false;
            isMovingForward = false;
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.SetTrigger("Jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
            isGrounded = false;
        }

        //move to desired position
        if (transform.position != desiredPosition)
        {
            Vector3 destination = new Vector3(desiredPosition.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, destination, horizontalSpeed * Time.deltaTime);
        }

        //check if player is falling
        if (transform.position.y < -1)
        {
            isFalling = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
            isFalling = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Hit Obstacle");
        }

        if (other.gameObject.CompareTag("Gold"))
        {
            Debug.Log("Hit Gold");
            Destroy(other.gameObject);
            score.score += 1;
        }
    }


}
