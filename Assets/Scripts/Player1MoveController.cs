using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1MoveController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI congratsText;
    public GameObject endscreen;
    private int moveCounter = 0;

    Vector2 movement;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            movement.x = -1;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            movement.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            movement.x = 1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            movement.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            movement.y = 1;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            movement.y = 0;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            movement.y = -1;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            movement.y = 0;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        counterText.text = "Adım Sayısı:" + (moveCounter / 20).ToString();
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cheese"))
        {
            Destroy(other.gameObject);
            endscreen.SetActive(true);
            moveSpeed = 0f;
            congratsText.text = "PLAYER 1 WINS!";

        }
    }
    


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (transform.hasChanged)
        {
            moveCounter++;
            transform.hasChanged = false;
        }
    }
}
