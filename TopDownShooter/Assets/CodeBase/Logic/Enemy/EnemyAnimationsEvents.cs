using UnityEngine;

namespace Assets.CodeBase.Logic.Enemy
{
    public class EnemyAnimationsEvents : MonoBehaviour
    {
        private Enemy enemy;
        private void Awake()
        {
            enemy = GetComponentInParent<Enemy>();
        }
        public void AnimationTrigger() => enemy.AnimationTrigger();
        public void StartManualMovement() => enemy.ActivateManualMovement(true);
        public void StopManualMovement() => enemy.ActivateManualMovement(false);
    }
}