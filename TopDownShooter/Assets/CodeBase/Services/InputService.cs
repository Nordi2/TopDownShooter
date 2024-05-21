using UnityEngine;

namespace Assets.CodeBase.Services
{
    public class InputService : MonoBehaviour
    {
        private PlayerController _playerController;

        public Vector2 _moveInput { get; private set; }
        public Vector2 _aimInput { get; private set; }
        private void Awake()
        {
            _playerController = new PlayerController();

            _playerController.Character.Movement.performed += context => _moveInput = context.ReadValue<Vector2>();
            _playerController.Character.Movement.canceled += context => _moveInput = Vector2.zero;

            _playerController.Character.Aim.performed += context => _aimInput = context.ReadValue<Vector2>();
            _playerController.Character.Aim.canceled += context => _aimInput = Vector2.zero;
        }
        private void OnEnable()
        {
            _playerController.Enable();
        }
        private void OnDisable()
        {
            _playerController.Disable();
        }
    }
}