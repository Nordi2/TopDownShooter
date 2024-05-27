using Assets.CodeBase.Logic.EnemyZombie;
using UnityEngine;

public class AttackState_ZombieMelee : EnemyState
{
    private EnemyZombie_Melee _enemy;
    private Vector3 _attackDirection;
    private float _attackMoveSpeed;
    private const float MAX_ATTACK_DISTANCE = 25f;
    public AttackState_ZombieMelee(Enemy enemyBase, Assets.CodeBase.Logic.EnemyZombie.EnemyStateMachine stateMachine, string animBollName) : base(enemyBase, stateMachine, animBollName)
    {
        _enemy = enemyBase as EnemyZombie_Melee;
    }

    public override void Enter()
    {
        base.Enter();

        _attackMoveSpeed = _enemy.MoveSpeed;

        _enemy.Agent.isStopped = true;
        _enemy.Agent.velocity = Vector3.zero;

        _attackDirection = _enemy.transform.position + _enemy.transform.forward * MAX_ATTACK_DISTANCE;
    }

    public override void Exit()
    {
        base.Exit();
        _enemy.Agent.isStopped = false;
    }

    public override void Update()
    {
        base.Update();
        if (_enemy.ManualMovementActive())
        {
           _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _attackDirection, _attackMoveSpeed * Time.deltaTime);
        }
        if (Vector3.Distance(_enemy.transform.position, _enemy._player.position) >= 1f && _triggerCalled)
        {
            _enemy.StateMachine.ChangeState(_enemy.MoveState);
        }
    }
}
