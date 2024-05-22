using Assets.CodeBase.Services;
using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.CodeBase.Logic.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private InputService _inputService;
        private PlayerAnimation _playerAnimation;
        [Header("Movement Info")]
        [SerializeField] private float _speed;
        private CharacterController _characterController;
        private Vector3 _moveDirection;
        private float _verticalVelocity;

        [Header("Looking Info")]
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Transform _aim;
        private Vector3 _lookingDirection;

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
            AimRotate();
            AnimationController();
        }
        private void OnShoot() =>
            _playerAnimation.Shoot();
        private void AimRotate()
        {
            Ray ray = Camera.main.ScreenPointToRay(_inputService._aimInput);
            if (Physics.Raycast(ray,out RaycastHit raycastHit,Mathf.Infinity,_layerMask))
            {
                _lookingDirection = raycastHit.point - transform.position;
                _lookingDirection.y = 0;
                _lookingDirection.Normalize();

                transform.forward = _lookingDirection;

                _aim.position = new Vector3(raycastHit.point.x, _aim.position.y, raycastHit.point.z);
            }
        }
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