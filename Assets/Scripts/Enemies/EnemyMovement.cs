using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    public float pathCalcSpeed = 0.2f;
    public Transform target;

    private NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.Instance.player.transform;
        StartCoroutine(FollowTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds wait = new WaitForSeconds(pathCalcSpeed);
        while (enabled)
        {
            _agent.SetDestination(target.transform.position);

            yield return wait;
        }
    }
}
