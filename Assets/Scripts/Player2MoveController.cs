using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player2MoveController : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movement.x = -1;
        } 
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            movement.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movement.x = 1;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            movement.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            movement.y = 1;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            movement.y = 0;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            movement.y = -1;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
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
            congratsText.text = "PLAYER 2 WINS!";

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
