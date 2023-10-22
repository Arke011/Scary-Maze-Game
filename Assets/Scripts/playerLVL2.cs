using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLVL2 : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;


        rb.velocity = moveDirection * moveSpeed;


        if (moveDirection == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("finish2"))
        {
            transform.position = new Vector3(4.04f, 6.5f, 0f);

            rb.velocity = Vector2.zero;
        }

        else if (collision.gameObject.CompareTag("finish2"))
        {
            SceneManager.LoadScene("Level3");
        }
    }
}
