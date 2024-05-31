using UnityEngine;

namespace Assets.CodeBase.Logic.EnemyZombie
{
    public class ResurrectionState_ZombieMelee : EnemyState
    {
        private EnemyZombie_Melee _enemy;
        public ResurrectionState_ZombieMelee(Enemy enemyBase, EnemyStateMachine stateMachine, string animBollName) : base(enemyBase, stateMachine, animBollName)
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
            if (_enemy.ManualMovementActive())
            {
                Vector3 moveDirection = _enemy.transform.position + _enemy.transform.forward * 200f;
                _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, moveDirection,0.5f* Time.deltaTime);
            }
            if (_triggerCalled)
            {
                 _enemy.StateMachine.ChangeState(_enemy.GetUpState);
            }
        }
    }
}