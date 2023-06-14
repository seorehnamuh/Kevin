using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement1 : MonoBehaviour
{
    public float speed = 10f; 
    public float jumpForce = 5f;
    private Rigidbody rb; 
    private bool isGrounded; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
  
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        transform.Translate(direction * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}