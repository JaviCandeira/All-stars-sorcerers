using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnLocation;

    private void Awake()
    {
        spawnLocation = GameObject.FindGameObjectWithTag("SpawnPoint");
    }

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        Instantiate(PlayerManager.Instance.player, spawnLocation.transform.position, Quaternion.identity);
    }
}
