using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovement : MonoBehaviour
    {
        public EnemyEyes eyes;
        public float pathCalcSpeed = 0.2f;
        public float idleWait;
        public float idleLocRadius;
        public Transform target;
        private NavMeshAgent _agent;
        private Coroutine FollowCoroutine;
        #region EnemyState
        public EnemyState DefaultState;
        public EnemyState State
        {
            get => _state;
            set => OnStateChange?.Invoke(_state, value);
        }
        public delegate void StateChange(EnemyState newState, EnemyState oldState);
        public StateChange OnStateChange;
     
        private EnemyState _state;
        #endregion
        
        // Start is called before the first frame update
        private void Start()
        {
            OnStateChange += HandleStateChange;
            eyes.OnGainView += HandleGainView;
            eyes.OnLoseView += HandleLoseView;
            _agent = GetComponent<NavMeshAgent>();
            target = PlayerManager.Instance.player.transform;
            OnStateChange?.Invoke(EnemyState.Initialize, DefaultState);
        }
        
        private void HandleGainView(Player player)
        {
            State = EnemyState.Chase;
        }

        private void HandleLoseView(Player player)
        {
            State = DefaultState;
        }
    
        private IEnumerator FollowTarget()
        {
            var wait = new WaitForSeconds(pathCalcSpeed);
            while (enabled)
            {
                _agent.SetDestination(target.transform.position);

                yield return wait;
            }
        }
        
        private IEnumerator BeIdle()
        {
            WaitForSeconds wait = new WaitForSeconds(idleWait);
            
            while (true)
            {
                yield return wait;
                if (_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    Vector2 point = Random.insideUnitCircle * idleLocRadius;
                    NavMeshHit hit;

                    if (NavMesh.SamplePosition(_agent.transform.position + new Vector3(point.x, 0, point.y), out hit, 5f, _agent.areaMask))
                    {
                        _agent.SetDestination(hit.position);
                    }
                }
            }
        }

        private void HandleStateChange(EnemyState oldState, EnemyState newState)
        {
            if (oldState != newState)
            {
                if (FollowCoroutine != null)
                {
                    StopCoroutine(FollowCoroutine);
                }
                switch (newState)
                {
                    case EnemyState.Idle:
                        FollowCoroutine = StartCoroutine(BeIdle());
                        break;
                    case EnemyState.Chase:
                        FollowCoroutine = StartCoroutine(FollowTarget());
                        break;
                }
            }
        }
    }
}
