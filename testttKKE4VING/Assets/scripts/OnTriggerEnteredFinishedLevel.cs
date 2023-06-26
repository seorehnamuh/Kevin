using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerEnteredFinishedLevel : MonoBehaviour
{
  

    private void OnTriggerEnter(Collider other)
    {
        

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            ChangeScene.Instance.HasFinishedlevel1 = true;
            SceneManager.LoadScene(0);
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            ChangeScene.Instance.HasFinishedlevel2 = true;
            SceneManager.LoadScene(0);
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            ChangeScene.Instance.HasFinishedlevel3 = true;
            SceneManager.LoadScene(0);
        }
    }
}
