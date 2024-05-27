using UnityEngine;

namespace Assets.CodeBase.Logic.EnemyZombie
{
    public class EnemyZombieAniamtionEvents : MonoBehaviour
    {
        private Enemy _enemy;
        private void Awake()
        {
            _enemy = GetComponentInParent<Enemy>();
        }
        public void AnimationTrigger() => _enemy.AnimationTrigger();
        public void StartManualMovement() => _enemy.ActivayeManualMovement(true);
        public void StopManualMovement() => _enemy.ActivayeManualMovement(false);
        public void StartManualRotation() => _enemy.ActivateManualRotation(true);
        public void StopManualRotation() => _enemy.ActivateManualRotation(false);
    }
}