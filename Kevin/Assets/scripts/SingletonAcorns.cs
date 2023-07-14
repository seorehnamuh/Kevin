using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonAcorns : MonoBehaviour
{

    private float numberOfAcorns;
    private float numberOfAcornsToOpenTheGate;
    public GameObject gate;
    private Animator gateAnimator;
   
    void Start()
    {
        numberOfAcorns = 0;
        numberOfAcornsToOpenTheGate = 10;
        gateAnimator = gate.GetComponent<Animator>();
    }

    
    void Update()
    {
        if (numberOfAcorns == numberOfAcornsToOpenTheGate)
        {
            gateAnimator.SetBool("isOpening", true);
        }
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
        Debug.Log(numberOfAcorns.ToString());
    }
}
