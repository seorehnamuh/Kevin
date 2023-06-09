using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Rock : MonoBehaviour
{
    public int damage = 1;
    public bool isEnemyShot = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == "Enemy")
        {
           collision.gameObject.GetComponent<Health>().currentHealth -= 10;
        }

        else
        {
            Destroy(gameObject);
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
