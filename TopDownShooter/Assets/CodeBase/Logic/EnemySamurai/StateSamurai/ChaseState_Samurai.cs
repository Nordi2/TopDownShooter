namespace Assets.CodeBase.Logic.EnemySamurai.StateSamurai
{
    public class ChaseState_Samurai : EnemyState_Samurai
    {
        private EnemySamurai_Melee _enemy;
        public ChaseState_Samurai(EnemySamurai enemyBase, EnemyStateMachine_Samurai stateMachine, string animBollName) : base(enemyBase, stateMachine, animBollName)
        {
            _enemy = enemyBase as EnemySamurai_Melee;
        }

        public override void Enter()
        {
            base.Enter();
            _enemy.Agent.speed = _enemy.ChaseSpeed;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            _enemy.transform.rotation = _enemy.FaceTarget(_enemy.Target.position);
            _enemy.Agent.SetDestination(_enemy.Target.position);
            if (_enemy.PlayerInAttackRange())
            {
                _enemy.StateMachine.ChangeState(_enemy.AttackState);
            }
        }
    }
}