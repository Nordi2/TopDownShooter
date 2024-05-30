namespace Assets.CodeBase.Logic.EnemyZombie
{
    public class DeadState_ZombieMelee : EnemyState
    {
        private EnemyZombie_Melee _enemy;
        private EnemyZombie_Ragdoll _enemyRagdoll;
        public DeadState_ZombieMelee(Enemy enemyBase, EnemyStateMachine stateMachine, string animBollName) : base(enemyBase, stateMachine, animBollName)
        {
            _enemy = enemyBase as EnemyZombie_Melee;
            _enemyRagdoll = _enemy.GetComponent<EnemyZombie_Ragdoll>();
        }

        public override void Enter()
        {
            base.Enter();
            _enemy.Animator.enabled = false;
            _enemy.Agent.isStopped = true;

            _enemyRagdoll.RagdollActive(true);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
        }
    }
}