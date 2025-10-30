using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
<<<<<<< HEAD
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
=======
    public float speed = 0;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private Rigidbody rb;
    private int count;

    // holds movement x and y
    private float movementX;
    private float movementY;
    // Start is called before the firs frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // sets rigidbody component to rb
>>>>>>> 80393f7726bf9d53c4627dcf5529842d2de4f0f3
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

<<<<<<< HEAD
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
=======
    void OnMove(InputValue movementValue)
    {
        // create a vector 2 variable and store the x and y movement values in it
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 25)
        {
            winTextObject.SetActive(true);

            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        // set the movement to the x and z variables (keep y at 0)
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

     
    }

>>>>>>> 80393f7726bf9d53c4627dcf5529842d2de4f0f3
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("blueBall"))
        {
            other.gameObject.SetActive(false);
<<<<<<< HEAD
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
=======
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("pinkBall"))
        {
            other.gameObject.SetActive(false);
            count = count + 5;
            SetCountText();
        }
        if (other.gameObject.CompareTag("blackBall"))
        {
            other.gameObject.SetActive(false);
            count = count + 10;
            SetCountText();
        }
        if (other.gameObject.CompareTag("greenBall"))
        {
            other.gameObject.SetActive(false);
            count = count + 3;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.SetActive(false);
            count = count + 6;
            SetCountText();
        }
    }
    private void OCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }
>>>>>>> 80393f7726bf9d53c4627dcf5529842d2de4f0f3
}
