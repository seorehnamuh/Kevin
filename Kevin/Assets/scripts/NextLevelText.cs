using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelText : MonoBehaviour
{
    public TextMeshProUGUI nextLevel;
  
    // Start is called before the first frame update
    void Start()
    {
    }
   
    IEnumerator ShowMessage(string message, float delay)
    {
        nextLevel.text = message;
        nextLevel.enabled = true;
        yield return new WaitForSeconds(delay);
        nextLevel.text = "";
        nextLevel.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Test"); 
            StartCoroutine(ShowMessage("You have been caught!", 5));
            ChangeScene.Instance.Level1Completed();
            StartCoroutine(Changeafter());
        }
    }
    IEnumerator Changeafter()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }
}
