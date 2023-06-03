using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement1 : MonoBehaviour
{
    public float movespeed = 5f;
    public float rotationSpeed = 3f;
    public float jumpforce = 5f;
    private CharacterController controller;
    private float verticalspeed;
    //public Transform spawnPoint;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizonthalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = (transform.forward * verticalMovement + transform.right * horizonthalMovement) * movespeed * Time.deltaTime;
        movement.y = verticalspeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            verticalspeed = jumpforce;

        }

        controller.Move(movement);

    }
}
