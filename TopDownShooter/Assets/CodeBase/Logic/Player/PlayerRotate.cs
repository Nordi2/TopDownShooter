using Assets.CodeBase.Services;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Logic.Player
{
    public class PlayerRotate : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Transform _aim;
        private Vector3 _lookingDirection;
        private InputService _inputService;
        [Inject]
        public void Construct(InputService inputService)
        {
            _inputService = inputService;
        }
        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(_inputService._aimInput);
            if (Physics.Raycast(ray,out RaycastHit raycastHit,Mathf.Infinity,_layerMask))
            {
                _lookingDirection = raycastHit.point - transform.position;
                _lookingDirection.y = 0;
                _lookingDirection.Normalize();

                transform.forward = _lookingDirection;

                _aim.position = new Vector3(raycastHit.point.x, transform.position.y + 1, raycastHit.point.z);
            }
        }
    }
}