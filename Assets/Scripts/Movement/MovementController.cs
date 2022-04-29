using UnityEngine;

namespace Movement
{
    public class MovementController : MonoBehaviour
    {
        public float moveSpeed = 7;

        private Animator _animator;
        private Rigidbody _body;
        private static readonly int IsMoving = Animator.StringToHash("isMoving");

        // Start is called before the first frame update
        void Start()
        {
            _body = GetComponent<Rigidbody>();
            _body.freezeRotation = true;
            _animator = GetComponent<Animator>();
        }

        public void Move(float horizontalInput, float verticalInput)
        {
            Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
            float magnitude = Mathf.Clamp01(moveDirection.magnitude) * moveSpeed;
            moveDirection.Normalize();

            if (moveDirection != Vector3.zero)
            {
                _animator.SetBool(IsMoving, true);
                //To stop the object from rotating back to default position
                Quaternion moveRotation = Quaternion.LookRotation(moveDirection);
                transform.Translate(moveDirection * magnitude * Time.deltaTime, Space.World);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, moveRotation, 360 * Time.deltaTime * 2);
            }
            else 
            if(_animator) _animator.SetBool(IsMoving, false);
        }
    }
}
