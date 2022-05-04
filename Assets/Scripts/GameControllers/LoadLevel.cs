using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private string nOfLevel;

    private int counter;
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
        GameObject collisionGameObject = other.gameObject;

        if (collisionGameObject.name == "Abe")
        {
            if(counter == 0){
                LoadScene();
            }
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(nOfLevel);
    }
}
