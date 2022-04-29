using System.Collections;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(SphereCollider))]
    public class EnemyEyes : MonoBehaviour
    {
        public SphereCollider collider;
        public LayerMask visionLayers;
        public float viewRadius;

        public delegate void GainView(Player player);
        public delegate void LoseView(Player player);
        public GainView OnGainView;
        public LoseView OnLoseView;
        
        
        private Coroutine _checkForPlayerCoroutine;
        // Start is called before the first frame update
        void Start()
        {
            collider = GetComponent<SphereCollider>();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            Player player;
            if (other.TryGetComponent<Player>(out player))
            {
                if (!CheckIfPlayerNearby(player))
                {
                    _checkForPlayerCoroutine = StartCoroutine(CheckForPlayer(player));
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent<Player>(out var player)) return;
            OnLoseView?.Invoke(player);
            if (_checkForPlayerCoroutine != null)
            {
                StopCoroutine(_checkForPlayerCoroutine);
            }
        }

        private bool CheckIfPlayerNearby(Player player)
        {
            var direction = (player.transform.position - transform.position).normalized;
            var dotProduct = Vector3.Dot(transform.forward, direction);
            if (!(dotProduct >= Mathf.Cos(viewRadius))) return false;

            if (Physics.Raycast(transform.position, direction, out var hit, collider.radius, visionLayers))
            {
                if (hit.transform.GetComponent<Player>() != null)
                {
                    OnGainView?.Invoke(player);
                    return true;
                }
            }

            return false;
        }

        private IEnumerator CheckForPlayer(Player player)
        {
            WaitForSeconds Wait = new WaitForSeconds(0.1f);

            while(!CheckIfPlayerNearby(player))
            {
                yield return Wait;
            }
        }
    }
}
