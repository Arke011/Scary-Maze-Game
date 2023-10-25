using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float moveSpeed = 5f;

    private void Update()
    {
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("finish"))
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if (collision.gameObject.CompareTag("finish"))
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
