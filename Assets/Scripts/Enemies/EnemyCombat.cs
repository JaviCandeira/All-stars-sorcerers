using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class EnemyCombat : MonoBehaviour
{
    public new SphereCollider collider;
    public int damage = 10;
    public float attackCooldown = 0.5f;
    public float attackDistance = 2f;
    public delegate void AttackEvent(IDamagable target);
    public AttackEvent OnAttack;
    private Coroutine _attackCoroutine;
    private IDamagable _player;

    private void Awake()
    {
        collider = GetComponent<SphereCollider>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        _player = other.GetComponent<IDamagable>();
        if (_player == null) return;
        _attackCoroutine ??= StartCoroutine(Obliterate());
    }
    
    private IEnumerator Obliterate()
    {
        var wait = new WaitForSeconds(attackCooldown);

        yield return wait;
        while (_player != null)
        {
            var playerTransform = _player.GetTransform();
            var distance = Vector3.Distance(transform.position, playerTransform.position);
            if (distance < attackDistance)
            {
                OnAttack?.Invoke(_player);
                _player.Damage(damage);
            }
            yield return wait;
        }

        _attackCoroutine = null;
    }
}
