using Assets.CodeBase.Services;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Logic.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement Info")]
        [SerializeField] private float _speed;
        private CharacterController _characterController;
        private Vector3 _moveDirection;
        private float _verticalVelocity;

        private InputService _inputService;
        private PlayerAnimation _playerAnimation;
        [Inject]
        public void Construct(InputService inputServic)
        {
            _inputService = inputServic;
        }
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _playerAnimation = GetComponentInChildren<PlayerAnimation>();
        }
        private void OnEnable() =>
            _inputService.OnShoot += OnShoot;
        private void OnDisable() =>
            _inputService.OnShoot -= OnShoot;
        private void Update()
        {
            ApplyMovement();
            AnimationController();
        }
        private void OnShoot() =>
            _playerAnimation.Shoot();
        private void AnimationController()
        {
            float xVelocity = Vector3.Dot(_moveDirection, transform.right);
            float zVelocity = Vector3.Dot(_moveDirection, transform.forward);

            _playerAnimation.Move(xVelocity, zVelocity);
        }
        private void ApplyMovement()
        {
            _moveDirection = new Vector3(_inputService._moveInput.x, 0, _inputService._moveInput.y);
            ApplyGravity();
            if (_moveDirection.magnitude > 0)
            {
                _characterController.Move(_moveDirection * _speed * Time.deltaTime);
            }
        }
        private void ApplyGravity()
        {
            if (!_characterController.isGrounded)
            {
                _verticalVelocity -= Constants.GravityScale * Time.deltaTime;
                _moveDirection.y = _verticalVelocity;
            }
            else
            {
                _moveDirection.y = -0.5f;
            }
        }
    }
}