using UnityEngine;

namespace Assets.CodeBase.Logic.Player
{
    public class PlayerAniamtionsEvent : MonoBehaviour
    {
        private WeaponVisual _weaponVisual;

        private void Awake()
        {
            _weaponVisual = GetComponentInParent<WeaponVisual>();
        }
        public void ReloadIsOver() =>
            _weaponVisual.ReturnRigWeightToOne();
    }
}