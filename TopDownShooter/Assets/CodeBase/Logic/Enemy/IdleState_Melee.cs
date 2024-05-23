namespace Assets.CodeBase.Logic.Enemy
{
    public class IdleState_Melee : EnemyState
    {
        private Enemy_Melee enemy;
        public IdleState_Melee(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
        {
            enemy = enemyBase as Enemy_Melee;
        }
        public override void Enter()
        {
            base.Enter();
            _stateTimer = _enemyBase.idleTime;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            if (enemy.PlayerInAggresionRange())
            {
                _stateMachine.ChangeState(enemy.recoveryState);
                return;
            }
            if (_stateTimer <0)
            {
                _stateMachine.ChangeState(enemy.MoveState);
            }
        }
    }
}