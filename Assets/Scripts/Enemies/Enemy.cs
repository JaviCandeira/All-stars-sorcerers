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
    public EnemyConfig config;
    public EnemyMovement enemyMovement;
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
        agent = GetComponent<NavMeshAgent>();
        enemyMovement = GetComponent<EnemyMovement>();
        _animator = GetComponent<Animator>();
        target = PlayerManager.Instance.player;
        SetupFromConfig();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (Time.time > lastAttackedAt + config.attackCooldown)
        {
            if (distance <= 2f)
            {
                _animator.SetTrigger(Attack);
                target.GetComponent<IDamagable>().Damage(config.attackDamage);
                lastAttackedAt = Time.time;
            }

        }
        _animator.SetBool(IsMoving, agent.velocity.magnitude > 0f);
    }


    private void SetupFromConfig()
    {
        currentHealth = config.health;
        agent.areaMask = config.areaMask;
        agent.height = config.height;
        agent.radius = config.radius;
        agent.acceleration = config.accelaration;
        agent.angularSpeed = config.angularSpeed;
        agent.obstacleAvoidanceType = config.obstacleAvoidanceType;
        agent.speed = config.speed;
        agent.avoidancePriority = config.avoidancePriority;
        agent.baseOffset = config.baseOffset;
        agent.stoppingDistance = config.stoppingDistance;
        enemyMovement.pathCalcSpeed = config.aiUpdateInterval;
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
