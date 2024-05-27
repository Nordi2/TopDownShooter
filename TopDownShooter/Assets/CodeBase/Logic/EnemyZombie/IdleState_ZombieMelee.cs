namespace Assets.CodeBase.Logic.EnemyZombie
{
    public class IdleState_ZombieMelee : EnemyState
    {
        private EnemyZombie_Melee _enemy;
        public IdleState_ZombieMelee(Enemy enemyBase,
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
          //  _stateTimer = _enemyBase.IdleTime;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            //if (_stateTimer < 0)
            //{
            //    _stateMachine.ChangeState(_enemy.MoveState);
            //}
        }
    }
}