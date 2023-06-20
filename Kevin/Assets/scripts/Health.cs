using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }

    private void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player took " + amount + " damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // TODO: Implement player death logic
        Debug.Log("Player has died.");
    }

   
}

// private void OnTriggerEnter(Collider other)
// {
//   TakeDamage(20);
// }


// Update is called once per frame
// void Update()
//{


    //if (Input.GetKeyDown(KeyCode.Space))
    //{
    //    TakeDamage(20);
    //}

//}

//}
