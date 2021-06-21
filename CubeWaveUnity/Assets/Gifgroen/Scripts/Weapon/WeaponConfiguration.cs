using System;
using Gifgroen.Player.Input;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Gifgroen.Weapon
{
    [CreateAssetMenu(fileName = "NewWeaponConfig", menuName = "Weapon/Config", order = 0)]
    public class WeaponConfiguration : ScriptableObject, CubeWaveInputAsset.IPlayerAttackActions
    {
        [SerializeField] private GameObject visual;
        
        [SerializeField] private Vector3 forward = Vector3.right;

        public event UnityAction FireEvent;
        
        private CubeWaveInputAsset _gameInput;

        #region Unity Lifecycle
        private void OnEnable()
        {
            if (_gameInput == null)
            {
                _gameInput = new CubeWaveInputAsset();
                _gameInput.PlayerAttack.SetCallbacks(this);
            }
            EnableGameplayInput();
        }

        private void OnDisable()
        {
            DisableAllInput();
        }
        #endregion
        
        public GameObject GetVisual()
        {
            return visual;
        }
        
        public Vector3 GetForward()
        {
            return forward;
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            if (FireEvent != null && context.phase == InputActionPhase.Performed)
            {
                FireEvent.Invoke();
            }
        }

        public void EnableGameplayInput()
        {
            _gameInput.PlayerAttack.Enable();
        }

        private void DisableAllInput()
        {
            _gameInput.PlayerAttack.Disable();
        }
    }
}