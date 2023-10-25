using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLVL3 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject jumpScareImage; 
    public AudioClip jumpScareSound; 

    private bool jumpScareActive = false;

    private void Update()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("skary"))
        {
            
            ActivateJumpScare();

            
            StartCoroutine(ResetAfterDelay(4f));
        }
        else if (collision.gameObject.CompareTag("finish3"))
        {
            
            SceneManager.LoadScene("SampleScene");
        }
        else
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
        
        yield return new WaitForSeconds(delay);

        
        jumpScareImage.SetActive(false);

        if (jumpScareActive)
        {
            
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Stop();

            
            

            
            SceneManager.LoadScene("SampleScene");
        }
    }
}
