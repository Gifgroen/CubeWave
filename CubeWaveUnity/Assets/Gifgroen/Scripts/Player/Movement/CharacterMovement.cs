using UnityEngine;

namespace Gifgroen.Player.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private CharacterRotation characterRotation;

        [SerializeField] private Rigidbody movable;

        [SerializeField, Range(1f, 10f)] private float maxMoveSpeed = 5f;

        [SerializeField, Range(0f, 100f)] private float maxMoveAcceleration = 64f;

        private Vector3 _desiredVelocity;

        private Vector3 _velocity;

        private void OnValidate()
        {
            movable = GetComponent<Rigidbody>();
        }

        private void Awake()
        {
            characterRotation.SetPreviousDirection(movable.transform.forward);
            characterRotation.SetDirection(Vector3.zero);
        }

        private void Update()
        {
            _desiredVelocity = characterRotation.GetMoveDirection() * maxMoveSpeed;
        }

        private void FixedUpdate()
        {
            DetermineMoveVelocity();
            characterRotation.MatchRotation(movable.transform);
        }

        private void DetermineMoveVelocity()
        {
            _velocity = movable.velocity;
            float maxSpeedChange = maxMoveAcceleration * Time.fixedDeltaTime;
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
            characterRotation.SetDirection(direction);
        }
    }
}