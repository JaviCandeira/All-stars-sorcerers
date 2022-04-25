using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Enemy Config", menuName = "EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    //Stat related
    public int health = 100;
    public int attackCooldown = 1;
    public int attackDamage = 10;
    
    //Agent related 
    public float aiUpdateInterval = 0.2f;
    public float accelaration = 8;
    public float angularSpeed = 120;
    public int areaMask = -1;
    public int avoidancePriority = 50;
    public float baseOffset = 0;
    public float height = 2f;
    public ObstacleAvoidanceType obstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
    public float radius = 0.5f;
    public float speed = 3f;
    public float stoppingDistance = 0.5f;



}
