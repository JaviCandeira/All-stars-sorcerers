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
        PlayerManager.Instance.player = Instantiate(PlayerManager.Instance.playerPrefab, spawnLocation.transform);
    }
}
