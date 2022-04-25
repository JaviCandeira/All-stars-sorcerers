using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class EnemyCombat : MonoBehaviour
{
    public SphereCollider collider;
    public int damage = 10;
    public float attackCooldown = 0.5f;
    public float attackDistance = 2f;
    public delegate void AttackEvent(IDamagable target);
    public AttackEvent onAttack;
    private Coroutine attackCoroutine;
    private IDamagable player;
    void Awake()
    {
        collider = GetComponent<SphereCollider>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<IDamagable>();
        if (player != null)
        {
            if (attackCoroutine == null)
            {
                attackCoroutine = StartCoroutine(Obliterate());
            }
        }
    }
    
    private IEnumerator Obliterate()
    {
        WaitForSeconds Wait = new WaitForSeconds(attackCooldown);

        yield return Wait;
        while (player != null)
        {
            Transform playerTransform = player.GetTransform();
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            if (distance < attackDistance)
            {
                onAttack?.Invoke(player);
                player.Damage(damage);
            }
            yield return Wait;
        }

        attackCoroutine = null;
    }
}
