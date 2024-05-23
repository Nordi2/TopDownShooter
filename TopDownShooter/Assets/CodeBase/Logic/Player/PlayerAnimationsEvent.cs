using UnityEngine;

namespace Assets.CodeBase.Logic.Player
{
    public class PlayerAnimationsEvent : MonoBehaviour
    {
        private WeaponVisual _weaponVisual;

        private void Awake()
        {
            _weaponVisual = GetComponentInParent<WeaponVisual>();
        }
        public void ReloadIsOver() =>
            _weaponVisual.ReturnRigWeightToOne();
        public void ReturnRig() 
        {
            _weaponVisual.MaximizeRigWeight();
            _weaponVisual.MaximizeLeftHandWeight();
        }
        public void WeaponGrabIsOver() 
        {
            _weaponVisual.SetBusyGrabbingWeaponTo(false);
        }
    }
}