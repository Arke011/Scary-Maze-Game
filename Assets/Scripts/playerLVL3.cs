using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLVL3 : MonoBehaviour
{
    public float moveSpeed = 2f;
    public GameObject jumpScareImage; 
    public AudioClip jumpScareSound; 

    private bool jumpScareActive = false;

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

        
        Vector2 velocity = moveDirection * moveSpeed * Time.deltaTime;

        
        rb.MovePosition(rb.position + velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("finish3"))
        {
            
            ActivateJumpScare();

            
            StartCoroutine(ResetAfterDelay(3f));
        }
        else if (!collision.gameObject.CompareTag("finish"))
        {
            
            transform.position = new Vector3(-2.01f, -6.43f, 0f);

            
            rb.velocity = Vector2.zero;
        }
        else if (collision.gameObject.CompareTag("finish"))
        {
            
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void ActivateJumpScare()
    {
       
        jumpScareImage.SetActive(true);

        
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = jumpScareSound;
        audioSource.Play();

        
        jumpScareActive = true;
    }

    private IEnumerator ResetAfterDelay(float delay)
    {
        
        yield return new WaitForSeconds(delay); //waits for 3 seconds :)

        
        jumpScareImage.SetActive(false);

        if (jumpScareActive)
        {
            
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Stop();

            
            transform.position = new Vector3(0f, -4.27f, 0f);

            
            rb.velocity = Vector2.zero;

            
            SceneManager.LoadScene("SampleScene");
        }
    }
}
