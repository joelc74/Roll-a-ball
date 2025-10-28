using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
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
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("blueBall"))
        {
            other.gameObject.SetActive(false);
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
}
