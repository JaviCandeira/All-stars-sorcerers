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
    public EnemyConfig config;
    public EnemyMovement enemyMovement;
    public EnemyCombat enemyCombat;
    public int currentHealth { get; set; }

    private NavMeshAgent agent;

    private Animator _animator;

    
    private Coroutine lookCoroutine;

    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private static readonly int Attack = Animator.StringToHash("Attack");

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyMovement = GetComponent<EnemyMovement>();
        _animator = GetComponent<Animator>();
        SetupFromConfig();
    }

    void Awake()
    {
        enemyCombat.onAttack = onAttack;
    }

    // Update is called once per frame
    void Update()
    {
        // float distance = Vector3.Distance(target.transform.position, transform.position);
        // if (Time.time > lastAttackedAt + config.attackCooldown)
        // {
        //     if (distance <= 2f)
        //     {
        //         _animator.SetTrigger(Attack);
        //         target.GetComponent<IDamagable>().Damage(config.attackDamage);
        //         lastAttackedAt = Time.time;
        //     }
        //
        // }
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
        enemyCombat.attackDistance = config.attackDistance;
        enemyCombat.attackCooldown = config.attackCooldown;
        enemyCombat.damage = config.attackDamage;
    }

    public void Damage(int damagePoints)
    {
        currentHealth -= damagePoints;
        if (currentHealth <= 0)
        {
            Perish();
        }
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Perish()
    {
        
    }
    
    private void onAttack(IDamagable target)
    {
        Debug.Log("I strike!");
        _animator.SetTrigger(Attack);

        if (lookCoroutine != null)
        {
            StopCoroutine(lookCoroutine);
        }

        lookCoroutine = StartCoroutine(LookAt(target.GetTransform()));
    }
    
    private IEnumerator LookAt(Transform target)
    {
        Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position);
        float time = 0;

        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);

            time += Time.deltaTime * 2;
            yield return null;
        }

        transform.rotation = lookRotation;
    }
}
