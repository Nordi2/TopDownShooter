namespace Assets.CodeBase.Logic.EnemySamurai.StateSamurai
{
    public class AttackState_Samurai : EnemyState_Samurai
    {
        private EnemySamurai_Melee _enemy;
        public AttackState_Samurai(EnemySamurai enemyBase, EnemyStateMachine_Samurai stateMachine, string animBollName) : base(enemyBase, stateMachine, animBollName)
        {
            _enemy = enemyBase as EnemySamurai_Melee;
        }

        public override void Enter()
        {
            base.Enter();
            _enemy.Agent.isStopped = true;
        }

        public override void Exit()
        {
            base.Exit();
            _enemy.Agent.isStopped = false;
        }

        public override void Update()
        {
            base.Update();
            if (!_enemy.PlayerInAttackRange() && _triggerCalled)
            {
                _enemy.StateMachine.ChangeState(_enemy.ChaseState);
            }
        }
    }
}