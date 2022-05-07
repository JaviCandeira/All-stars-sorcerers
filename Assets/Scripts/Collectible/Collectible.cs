using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
    private void Update()
    {
        transform.Rotate(new Vector3(0f,0.1f,0f));
    }

    private void OnTriggerEnter(Collider other)
    {
      var collisionGameObject = other.gameObject;

      if (collisionGameObject.name != "Abe") return;
      if (collectSound)
      {
          AudioSource.PlayClipAtPoint(collectSound, transform.position);
      }

      ScoreCounter.Instance.increase(20);
      Destroy(gameObject);
    }
}
