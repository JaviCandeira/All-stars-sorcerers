using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int maxHealth = 100;

    public int maxMana = 200;

    public int currentHealth;

    public int currentMana;

    public int attackDamage;

    public int attackCooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
    }

    // public void TakeDamage(int damagePoints)
    // {
    //     currentHealth -= damagePoints;
    //     Debug.Log("oof: " + currentHealth);
    // }

}
