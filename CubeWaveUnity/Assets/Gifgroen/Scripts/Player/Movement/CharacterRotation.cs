using UnityEngine;

namespace Gifgroen.Player.Movement
{
    public class CharacterRotation : MonoBehaviour
    {
        [SerializeField, Range(1, 100)] private float rotateSpeed = 24f;

        private Vector3 _previousMoveDirection;

        private Vector3 _moveDirection;

        public Vector3 GetMoveDirection()
        {
            return _moveDirection;
        }

        public void SetDirection(Vector3 direction, bool cachePrevious = true)
        {
            if (cachePrevious)
            {
                _previousMoveDirection = _moveDirection;
            }

            _moveDirection = direction;
        }

        public void SetPreviousDirection(Vector3 direction)
        {
            _previousMoveDirection = direction;
        }

        public void MatchRotation(Transform movable)
        {
            bool isMoving = _moveDirection != Vector3.zero;
            Vector3 currentDirection = isMoving ? _moveDirection : _previousMoveDirection;

            if (movable.rotation != Quaternion.LookRotation(currentDirection))
            {
                movable.rotation = Quaternion.Slerp(movable.rotation,
                    Quaternion.LookRotation(currentDirection), Time.deltaTime * rotateSpeed);
            }
            else
            {
                // TODO: notify of target direction.
            }
        }
    }
}