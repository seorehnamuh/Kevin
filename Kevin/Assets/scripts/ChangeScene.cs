using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public bool HasFinishedlevel1 = false;
    //public bool HasFinishedlevel2 = false;
    public bool HasFinishedlevel3 = false;

    public static ChangeScene Instance;

    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject);

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

    }


    public void ChangeToScene(int num)
    {
        if (num == 1)
        {
            SceneManager.LoadScene(2);
        }

     

        if (HasFinishedlevel1 && num == 3)
        {
            SceneManager.LoadScene(3);
        }


    }


    public void Level1Completed()
    {
        HasFinishedlevel1 = true;
    }

}
