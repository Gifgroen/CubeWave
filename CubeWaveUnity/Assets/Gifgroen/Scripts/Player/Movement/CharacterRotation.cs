using System;
using UnityEngine;

namespace Gifgroen.Player.Movement
{
    public class CharacterRotation: MonoBehaviour
    {
        [SerializeField, Range(1, 100)] private float rotateSpeed = 24f;

        private Vector3 _previousMoveDirection;

        private Vector3 _moveDirection;

        public Vector3 GetMoveDirection()
        {
            return _moveDirection;
        }
        
        public void SetDirection(Vector3 direction)
        {
            _previousMoveDirection = _moveDirection;
            _moveDirection = direction;
        }
        
        public void SetPreviousDirection(Vector3 direction)
        {
            _previousMoveDirection = direction;
        }

        public void MatchRotation(Transform movable)
        {
            if (_moveDirection != Vector3.zero)
            {
                if (movable.rotation != Quaternion.LookRotation(_moveDirection))
                {
                    movable.rotation = Quaternion.Slerp(movable.rotation,
                        Quaternion.LookRotation(_moveDirection), Time.deltaTime * rotateSpeed);
                }
                else
                {
                    // TODO: notify of target direction.
                }
            }
            else
            {
                if (_previousMoveDirection == Vector3.zero)
                {
                    return;
                }
                if (movable.rotation != Quaternion.LookRotation(_previousMoveDirection))
                {
                    movable.rotation = Quaternion.Slerp(movable.rotation,
                        Quaternion.LookRotation(_previousMoveDirection), Time.deltaTime * rotateSpeed);
                }
                else
                {
                    // TODO: notify of target direction.
                }
            }
        }
    }
}