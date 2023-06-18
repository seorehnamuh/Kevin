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

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage(20);
    }


    // Update is called once per frame
    void Update()
    {
      

            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    TakeDamage(20);
            //}

    }

        void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
