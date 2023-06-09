using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetTask : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI goalText;
    [SerializeField] List<GameObject> acorns;
    void Start()
    {
        goalText.enabled = false;
        acorns.ForEach(x => x.SetActive(false));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Task"))
        {
            StartCoroutine(ShowMessage("Get all acorns", 5));
            Destroy(collision.gameObject);
        }
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        goalText.text = message;
        goalText.enabled = true;
        yield return new WaitForSeconds(delay);
        goalText.enabled = false;
    }
}
