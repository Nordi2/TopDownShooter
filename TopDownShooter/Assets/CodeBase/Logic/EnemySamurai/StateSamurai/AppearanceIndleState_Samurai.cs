using Assets.CodeBase.Logic.EnemySamurai;
using UnityEngine;

public class AppearanceIndleState_Samurai : EnemyState_Samurai
{
    private EnemySamurai_Melee _enemy;
    public AppearanceIndleState_Samurai(EnemySamurai enemyBase, EnemyStateMachine_Samurai stateMachine, string animBollName) : base(enemyBase, stateMachine, animBollName)
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
        if (_triggerCalled)
        {
            _enemy.StateMachine.ChangeState(_enemy.WalkState);
        }
    }
}
