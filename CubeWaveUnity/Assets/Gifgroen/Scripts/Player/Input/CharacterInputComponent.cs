using Gifgroen.Player.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gifgroen.Player.Input
{
    public class CharacterInputComponent : MonoBehaviour
    {
        [SerializeField] public CharacterMovementComponent movement;

        // ReSharper disable once UnusedMember.Global
        public void Move(InputAction.CallbackContext c)
        {
            Vector2 value = c.ReadValue<Vector2>();
            if (value.x > 0)
            {
                movement.SetMoveRight();
            }
            else if (value.x < 0f)
            {
                movement.SetMoveLeft();
            }
            else
            {
                movement.SetStopMove();
            }
        }
    }
}