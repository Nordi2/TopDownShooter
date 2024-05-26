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
            _destination = _enemy.GetPatrolDestination();

            _enemy.Agent.SetDestination(_destination);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (_enemy.Agent.remainingDistance <= 1)
            {
                _stateMachine.ChangeState(_enemy.IdleState);
            }
        }     
    }
}