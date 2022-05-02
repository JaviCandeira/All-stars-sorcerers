using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Enemy Config", menuName = "EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    //Stat related
    public int health = 100;
    public float attackCooldown = 1f;
    public int attackDamage = 10;
    public float attackDistance = 1.5f;
    public EnemyState defaultState;

    //Agent related 
    public float aiUpdateInterval = 0.2f;
    public float acceleration = 8;
    public float angularSpeed = 120;
    public int areaMask = -1;
    public int avoidancePriority = 50;
    public float baseOffset = 0;
    public float height = 2f;
    public ObstacleAvoidanceType obstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
    public float radius = 0.5f;
    public float speed = 3f;
    public float stoppingDistance = 0.5f;
    
    //Move related
    public float idleLocRadius = 4f;
    public float viewRadius = 360f;
    public float viewRange = 6f;
    public float idleWaitTime = 3f;



}
