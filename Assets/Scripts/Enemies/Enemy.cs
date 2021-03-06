using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class Enemy : MonoBehaviour, IDamagable, IKillable
    {
        public EnemyConfig config;
        public EnemyMovement enemyMovement;
        public EnemyCombat enemyCombat;
        private int CurrentHealth { get; set; }
        private int score;

        private NavMeshAgent _agent;

        private Animator _animator;


        private Coroutine _lookCoroutine;

        private static readonly int IsMoving = Animator.StringToHash("isMoving");
        private static readonly int Attack = Animator.StringToHash("Attack");

        // Start is called before the first frame update
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            enemyMovement = GetComponent<EnemyMovement>();
            SetupFromConfig();
            enemyCombat.OnAttack = OnAttack;
        }

        // Update is called once per frame
        private void Update()
        {
            _animator.SetBool(IsMoving, _agent.velocity.magnitude > 0f);
        }

        private void SetupFromConfig()
        {
            CurrentHealth = config.health;
            _agent.areaMask = config.areaMask;
            _agent.height = config.height;
            _agent.radius = config.radius;
            _agent.acceleration = config.acceleration;
            _agent.angularSpeed = config.angularSpeed;
            _agent.obstacleAvoidanceType = config.obstacleAvoidanceType;
            _agent.speed = config.speed;
            _agent.avoidancePriority = config.avoidancePriority;
            _agent.baseOffset = config.baseOffset;
            _agent.stoppingDistance = config.stoppingDistance;
            enemyMovement.idleLocRadius = config.idleLocRadius;
            enemyMovement.eyes.viewRadius = config.viewRadius;
            enemyMovement.eyes.collider.radius = config.viewRange;
            enemyMovement.pathCalcSpeed = config.aiUpdateInterval;
            enemyMovement.DefaultState = config.defaultState;
            enemyMovement.idleWait = config.idleWaitTime;
            enemyCombat.attackDistance = config.attackDistance;
            enemyCombat.attackCooldown = config.attackCooldown;
            enemyCombat.damage = config.attackDamage;
            score = config.score;
        }

        public void Damage(int damagePoints)
        {
            CurrentHealth -= damagePoints;
            Debug.Log("Enemy is at: " + CurrentHealth + " health");
            if (CurrentHealth <= 0)
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
            Destroy(gameObject);
            ScoreCounter.Instance.increase(score);
        }

        private void OnAttack(IDamagable target)
        {
            _animator.SetTrigger(Attack);

            if (_lookCoroutine != null)
            {
                StopCoroutine(_lookCoroutine);
            }

            _lookCoroutine = StartCoroutine(LookAt(target.GetTransform()));
        }

        private IEnumerator LookAt(Transform target)
        {
            var lookRotation = Quaternion.LookRotation(target.position - transform.position);
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
}
