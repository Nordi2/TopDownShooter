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
        public void OnGetUp() => _enemy.GetUp();
        public void StartMoveResurection() => _enemy.ActivayeMoveResurection(true);
        public void StopMoveResurection() => _enemy.ActivayeMoveResurection(false);
        public void ResurectOff() => _enemy.ActivateResurect(true);
    }
}