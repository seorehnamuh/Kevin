using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_Person_Script : MonoBehaviour
{
    public float jumpPower = 2f; // Potenza del salto
    public float moveSpeedMultiplier = 4f; // Moltiplicatore di velocità del movimento

    public float movingTurnSpeed = 360f; // Velocità di rotazione in movimento
    public float stationaryTurnSpeed = 180f; // Velocità di rotazione fermo
    private Rigidbody rigidBody; // Riferimento al Rigidbody del personaggio
    private bool isGrounded; // Flag per indicare se il personaggio è a terra
    private float turnAmount; // Quantità di rotazione richiesta
    private float forwardAmount; // Quantità di movimento in avanti richiesta
    private Vector3 groundNormal; // Normale del terreno
    private Transform cam; // Riferimento alla telecamera principale
    private Vector3 camForward; // Direzione in avanti della telecamera
    private Vector3 move; // Direzione del movimento
    private bool jump; // Flag per indicare se il personaggio deve saltare


    private void Start()
    {

        rigidBody = GetComponent<Rigidbody>(); // Acquisizione del Rigidbody del personaggio

        rigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        // Blocca la rotazione del Rigidbody per evitare rotazioni indesiderate

        cam = Camera.main.transform; // Acquisizione della telecamera principale
    }

    private void Update()
    {
        if (!jump)
        {
            jump = Input.GetButtonDown("Jump");
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); // Input dell'asse orizzontale
        float v = Input.GetAxis("Vertical"); // Input dell'asse verticale

        if (cam != null)
        {
            camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
            // Calcolo della direzione di movimento relativa alla telecamera
            move = v * camForward + h * cam.right;
        }
        else
        {
            move = v * Vector3.forward + h * Vector3.right;
            // Calcolo della direzione di movimento in base alla direzione di default del personaggio
        }

        Move(move, jump); // Esegue la funzione di movimento del personaggio
        jump = false;
    }

    public void Move(Vector3 move, bool jump)
    {
        if (move.magnitude > 1f)
        {
            move.Normalize(); // Normalizza il vettore di movimento se ha una magnitudine maggiore di 1
        }

        move = transform.InverseTransformDirection(move); // Converte la direzione del movimento in una direzione relativa al personaggio

        move = Vector3.ProjectOnPlane(move, groundNormal);
        // Proietta il vettore di movimento sulla superficie del terreno per evitare movimenti in pendenza

        turnAmount = Mathf.Atan2(move.x, move.z); // Calcola la quantità di rotazione richiesta
        forwardAmount = move.z; // Calcola la quantità di movimento in avanti richiesta

        float turnSpeed = Mathf.Lerp(stationaryTurnSpeed, movingTurnSpeed, forwardAmount);
        // Calcola la velocità di rotazione richiesta in base alla quantità di movimento in avanti

        transform.Rotate(0f, turnAmount * turnSpeed * Time.deltaTime, 0f);
        // Ruota il personaggio in base alla quantità di rotazione richiesta

        if (move.magnitude > 0.1f)
        {
            transform.Translate(move * moveSpeedMultiplier * Time.deltaTime, Space.Self);


            // Sposta il personaggio in base alla direzione di movimento e alla velocità di movimento moltiplicata per il delta time
        }

        if (jump && isGrounded)
        {
            rigidBody.AddForce(transform.up * jumpPower, ForceMode.Impulse);
            // Applica una forza verso l'alto al personaggio per farlo saltare
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true; // Imposta il personaggio come "a terra"
        }
    }

}

