using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private string nOfLevel;
    [SerializeField] private int minimumScore;
    [SerializeField] private Material tpokaymaterial;
    [SerializeField] private Renderer renderer;
    public ParticleSystem particles;
    private bool tpokay = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(ScoreCounter.Instance.getScore() >= minimumScore)
        {
          if(!tpokay) {
            showOkay();
          }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collisionGameObject = other.gameObject;

        if (collisionGameObject.name == "Abe")
        {
          if(tpokay)
            {
                LoadScene();
            }
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(nOfLevel);
    }

    void showOkay(){
      tpokay = true;
      renderer.material = tpokaymaterial;
      Instantiate(particles, transform.position, Quaternion.Euler(-90, 0, 0) );
      particles.Clear();
    }
}
