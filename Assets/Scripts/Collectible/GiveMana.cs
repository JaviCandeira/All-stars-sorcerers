using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveMana : MonoBehaviour
{
    public int amount = 10;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        var collisionGameObject = other.gameObject;
        var player = collisionGameObject.GetComponent<Player>();
        var manaDiff = player.maxMana - PlayerManager.Instance.CurrentMana;
        if (collisionGameObject.name != "Abe") return;
        if (manaDiff > amount)
        {
            player.ReplenishMana(amount);
        }
        else if(manaDiff > 0 || manaDiff < amount)
        {
            player.ReplenishMana(Math.Round(manaDiff));
        }
        Destroy(gameObject);
    }
}
