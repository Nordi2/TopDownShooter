using UnityEngine;

namespace Assets.CodeBase.Logic.ObjectInteractable
{
    public class ObjectInteractable : MonoBehaviour, IObjectInteractable
    {
        [SerializeField] private GameObject _pickupFX; 
        public void PickUp()
        {
            Instantiate(_pickupFX, transform.position, Quaternion.identity);
            Destroy();
        }
        private void Destroy()
        {
            Destroy(gameObject);
        }

    }
}