using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 10f;
    public float jumpForce = 5f;

    [Header("UI Elements")]
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    // Called when the player moves (Input System)
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // Called when the player jumps (Input System)
    void OnJump(InputValue value)
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Update physics movement
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    // Check when player collects objects
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("blueBall"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("pinkBall"))
        {
            other.gameObject.SetActive(false);
            count += 5;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("blackBall"))
        {
            other.gameObject.SetActive(false);
            count += 10;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("greenBall"))
        {
            other.gameObject.SetActive(false);
            count += 3;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.SetActive(false);
            count += 6;
            SetCountText();
        }
         if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }

    // Check collisions (enemy or ground)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

       
    }

    // Helper: checks if player is grounded using a raycast
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    // Updates the UI counter and checks for win condition
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 25)
        {
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!";
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
}
