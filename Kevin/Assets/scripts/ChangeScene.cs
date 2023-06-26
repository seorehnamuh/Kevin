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
            SceneManager.LoadScene(1);
        }

        //if (HasFinishedlevel1 && num == 2)
        //{
        //    SceneManager.LoadScene(2);
        //}

        if (HasFinishedlevel1 && num == 3)
        {
            SceneManager.LoadScene(3);
        }


    }



    // appena ci sarà lo script del cancello, ovvero kevin che oltrepassa il trigger del cancello, inserire .--->
    // public void OnCollisioneEnter (Collision other)
    // { 
    // if(collision.gameObject.compareTag("Player")
    //   {
    // ChangeScene.HasFinishedlevel1 = true;
    // ChangeToScene(2)
    //   }
    // }



}
