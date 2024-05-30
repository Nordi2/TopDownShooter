namespace Assets.CodeBase.Logic.EnemyZombie
{
    public class RecoveryState_ZombieMelee : EnemyState
    {
        private EnemyZombie_Melee _enemy;
        public RecoveryState_ZombieMelee(Enemy enemyBase, EnemyStateMachine stateMachine, string animBollName) : base(enemyBase, stateMachine, animBollName)
        {
            _enemy = enemyBase as EnemyZombie_Melee;
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
            _enemy.transform.rotation = _enemy.FaceTarget(_enemy._player.position);
            if (_triggerCalled)
            {
                _stateMachine.ChangeState(_enemy.AttackState);
            }
        }
    }
}