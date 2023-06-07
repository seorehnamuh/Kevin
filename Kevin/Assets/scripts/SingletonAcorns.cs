using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonAcorns : MonoBehaviour
{

    private float numberOfAcorns;
        
   
    void Start()
    {
        numberOfAcorns = 0;
    }

    
    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Acorn"))
        {
            IncreaseNumberOfAcorns();
            Destroy(collision.gameObject);
        }
    }
    private void IncreaseNumberOfAcorns()
    {
        numberOfAcorns += 1;
    }
}
