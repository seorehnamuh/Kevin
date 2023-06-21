using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject ProjectilePrefab; // Prefab del proiettile
    public Transform spawnPoint; // Punto di spawn del proiettile
    public float projectileSpeed = 10f; // Velocità del proiettile
    /// Il danno che viene inflitto dal proiettile.

    public float TimeToDestroyTheProjectile = 3f; // Tempo prima di distruggere il proiettile

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // Verifica se il pulsante sinistro del mouse è stato premuto
        {
            GameObject projectile = Instantiate(ProjectilePrefab, spawnPoint.position, spawnPoint.rotation);
            // Istanza il prefab del proiettile nel punto di spawn con la rotazione del punto di spawn

            Rigidbody rb = projectile.GetComponent<Rigidbody>(); // Ottiene il componente Rigidbody del proiettile
            rb.velocity = spawnPoint.forward * projectileSpeed;
            // Imposta la velocità del proiettile nella direzione in avanti del punto di spawn moltiplicata per la velocità del proiettile
            rb.AddForce(projectileSpeed * spawnPoint.forward * Time.fixedDeltaTime, ForceMode.Impulse);

            Destroy(projectile, TimeToDestroyTheProjectile);
            // Distrugge il proiettile dopo il tempo specificato
        }
    }

}
