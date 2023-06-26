using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trasparentcamera : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            MeshRenderer rend = other.transform.GetComponent<MeshRenderer>();
            if (rend != null)
            {
                rend.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            MeshRenderer rend = other.transform.GetComponent<MeshRenderer>();
            if (rend != null)
            {
                rend.enabled = false;
            }
        }
    }
}
