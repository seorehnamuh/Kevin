using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Rock : MonoBehaviour
{
    public float speed = 10f; // Speed of the bullet
    public int damage = 10; // Amount of damage the bullet inflicts

    void Update()
    {
        // Move the bullet forward
    //    transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the bullet collided with an enemy
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            // Inflict damage on the enemy health
            enemyHealth.TakeDamage(damage);

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}