using System;
using System.Collections;
using System.Collections.Generic;
using Combat;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using UnityEngine.Timeline;

public class Enemy : MonoBehaviour, IDamagable, IKillable
{
    public float lookRadius = 7f;
    public Stats stats;
    
    public int currentHealth { get; set; }
    private GameObject target;

    private NavMeshAgent agent;

    private Animator _animator;

    private float lastAttackedAt = -999f;
    

    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private static readonly int Attack = Animator.StringToHash("Attack");

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = stats.maxHealth;
        agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        target = PlayerManager.Instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (Time.time > lastAttackedAt + stats.attackCooldown)
        {
            
            if (distance < lookRadius)
            {
                agent.SetDestination(target.transform.position);
            }

            if (distance <= 3f)
            {
                _animator.SetTrigger(Attack);
                target.GetComponent<IDamagable>().Damage(stats.attackDamage);
                lastAttackedAt = Time.time;
            }

        }
        _animator.SetBool(IsMoving, agent.velocity.magnitude > 0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void Damage(int damagePoints)
    {
        currentHealth -= damagePoints;
        if (currentHealth <= 0)
        {
            Perish();
        }
    }

    public void Perish()
    {
        
    }
}
