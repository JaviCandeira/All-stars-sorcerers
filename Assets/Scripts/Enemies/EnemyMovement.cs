using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovement : MonoBehaviour
    {
        public float pathCalcSpeed = 0.2f;
        public Transform target;

        private NavMeshAgent _agent;
        // Start is called before the first frame update
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            target = PlayerManager.Instance.player.transform;
            StartCoroutine(FollowTarget());
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
    }
}
