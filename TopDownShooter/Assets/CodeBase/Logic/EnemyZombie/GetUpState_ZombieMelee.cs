using UnityEngine;

namespace Assets.CodeBase.Logic.EnemyZombie
{
    public class GetUpState_ZombieMelee : EnemyState
    {
        private EnemyZombie_Melee _enemy;
        public GetUpState_ZombieMelee(Enemy enemyBase, EnemyStateMachine stateMachine, string animBollName) : base(enemyBase, stateMachine, animBollName)
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
            if (_enemy.IsGetUp())
            {
                _enemy.StateMachine.ChangeState(_enemy.MoveState);
            }
        }
    }
}