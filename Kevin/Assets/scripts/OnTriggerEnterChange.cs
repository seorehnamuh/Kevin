using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterChange : MonoBehaviour
  
{
    public int SceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        ChangeScene.Instance.ChangeToScene(SceneNumber);
    }
}
