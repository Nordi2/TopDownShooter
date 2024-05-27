using UnityEngine;

namespace Assets.CodeBase.Logic.EnemyZombie
{
    public class MoveState_ZombieMelee : EnemyState
    {
        private EnemyZombie_Melee _enemy;
        private Vector3 _destination;
        public MoveState_ZombieMelee(Enemy enemyBase,
            EnemyStateMachine stateMachine,
            string animBollName)
            : base(enemyBase,
                  stateMachine,
                  animBollName)
        {
            _enemy = enemyBase as EnemyZombie_Melee;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            _destination = _enemy._player.position;
            _enemy.Agent.SetDestination(_destination);
            _enemy.transform.rotation = _enemy.FaceTarget(_enemy._player.position);
            //if (_enemy.Agent.remainingDistance <= 1f)
            //{              
            //    _enemy.StateMachine.ChangeState(_enemy.AttackState);
            //}
            if (Vector3.Distance(_enemy.transform.position, _enemy._player.position) <= 1f)
            {
                _enemy.StateMachine.ChangeState(_enemy.AttackState);
            }
        }
    }
}