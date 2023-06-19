using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class testmove : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 5f;
    public float jumpForce = 5f;
    private CharacterController characterController;
    private CinemachineFreeLook freeLookCamera;
    private Quaternion smoothRotation; // Rotazione smoothed
    private bool isJumping = false;
    private float verticalVelocity = 0f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        freeLookCamera = FindObjectOfType<CinemachineFreeLook>();
    }

    private void Update()
    {
        // Calcola la rotazione del giocatore in base all'asse X della telecamera FreeLook
        float cameraRotationX = freeLookCamera.m_XAxis.Value;
        Quaternion playerRotation = Quaternion.Euler(0f, cameraRotationX, 0f);
        smoothRotation = Quaternion.Slerp(smoothRotation, playerRotation, Time.deltaTime * rotationSpeed);
        transform.rotation = smoothRotation;

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calcola la direzione di movimento basata sulla rotazione del giocatore
        Vector3 movementDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        movementDirection.y = 0f; // Imposta la componente Y a 0 per evitare il movimento verticale

        // Normalizza la direzione del movimento se la lunghezza supera 1
        if (movementDirection.magnitude > 1f)
            movementDirection.Normalize();

        // Applica la velocità di movimento al Character Controller
        characterController.Move(movementDirection * movementSpeed * Time.deltaTime);

        // Gestione del salto
        if (characterController.isGrounded)
        {
           
            isJumping = false;
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            verticalVelocity = jumpForce;
        }

        // Applica la forza di gravità
        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        // Applica la velocità verticale al Character Controller
        characterController.Move(new Vector3(0f, verticalVelocity, 0f) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
            verticalVelocity = 0f; // Resettiamo la velocità verticale quando tocca il suolo
        }
    }

}
