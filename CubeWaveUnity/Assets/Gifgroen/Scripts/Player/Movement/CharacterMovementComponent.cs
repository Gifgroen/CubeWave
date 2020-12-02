using UnityEngine;

namespace Gifgroen.Player.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterMovementComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody movable;

        [Range(1f, 10f)] [SerializeField] private float maxSpeed = 5f;

        [SerializeField, Range(0f, 100f)] private float maxAcceleration = 64f;

        private Vector3 _desiredVelocity;

        private Vector3 _velocity;

        private Vector3 _moveDirection = Vector3.zero;

        private void OnValidate()
        {
            movable = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _desiredVelocity = _moveDirection * maxSpeed;
        }

        private void FixedUpdate()
        {
            _velocity = movable.velocity;
            float maxSpeedChange = maxAcceleration * Time.fixedDeltaTime;
            _velocity.x = Mathf.MoveTowards(_velocity.x, _desiredVelocity.x, maxSpeedChange);
            _velocity.y = Mathf.MoveTowards(_velocity.y, _desiredVelocity.y, maxSpeedChange);
            _velocity.z = Mathf.MoveTowards(_velocity.z, _desiredVelocity.z, maxSpeedChange);
            movable.velocity = _velocity;
        }

        // ReSharper disable once UnusedMember.Global
        public void SetMoveLeft() => SetMoveDirection(Vector3.left);

        // ReSharper disable once UnusedMember.Global
        public void SetMoveRight() => SetMoveDirection(Vector3.right);

        // ReSharper disable once UnusedMember.Global
        public void SetStopMove() => SetMoveDirection(Vector3.zero);

        private void SetMoveDirection(Vector3 direction)
        {
            _moveDirection = direction;
        }
    }
}