using Assets.CodeBase.Logic.ObjectInteractable;
using UnityEngine;

namespace Assets.CodeBase.Logic.Player
{
    public class PlayerInteractable : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IObjectInteractable objectInteractable ))
            {
                objectInteractable.PickUp();
            }
        }
    }
}