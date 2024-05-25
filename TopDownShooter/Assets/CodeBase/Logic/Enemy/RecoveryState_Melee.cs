public class RecoveryState_Melee : Assets.CodeBase.Logic.Enemy.EnemyState
{
    private Enemy_Melee enemy;
    public RecoveryState_Melee(Assets.CodeBase.Logic.Enemy.Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        enemy = enemyBase as Enemy_Melee;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.agent.isStopped = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        enemy.transform.rotation = enemy.FaceTarget(enemy.player.position);

        if (triggerCalled)
        {
            _stateMachine.ChangeState(enemy.chaseState);
        }
    }
}
