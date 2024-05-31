using UnityEngine;

namespace Assets.CodeBase.Logic.EnemySamurai.StateSamurai
{
    public class WalkState_Samurai : EnemyState_Samurai
    {
        private EnemySamurai_Melee _enemy;
        private Vector3 _destination;
        public WalkState_Samurai(EnemySamurai enemyBase, EnemyStateMachine_Samurai stateMachine, string animBollName) : base(enemyBase, stateMachine, animBollName)
        {
            _enemy = enemyBase as EnemySamurai_Melee;
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
            _destination = _enemy.Target.position;
            _enemy.Agent.SetDestination(_destination);
            if (_enemy.PlayerInAgresionRange())
            {
                _enemy.StateMachine.ChangeState(_enemy.IntroductionState);
            }
        }
    }
}