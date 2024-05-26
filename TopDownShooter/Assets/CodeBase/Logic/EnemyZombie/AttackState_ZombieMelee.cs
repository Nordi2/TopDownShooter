using Assets.CodeBase.Logic.EnemyZombie;
using UnityEngine;

public class AttackState_ZombieMelee : EnemyState
{
    private EnemyZombie_Melee _enemy;
    public AttackState_ZombieMelee(Enemy enemyBase, Assets.CodeBase.Logic.EnemyZombie.EnemyStateMachine stateMachine, string animBollName) : base(enemyBase, stateMachine, animBollName)
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
    }
}
