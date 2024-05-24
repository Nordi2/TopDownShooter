using Assets.CodeBase.Logic.Enemy;
using System.Collections.Generic;
using UnityEngine;

public class AttackState_Melee : EnemyState
{
    private Enemy_Melee enemy;
    private Vector3 attackDirection;
    private float attackMoveSpeed;
    private const float MAX_ATTACK_DISTANCE = 50f;
    public AttackState_Melee(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        enemy = enemyBase as Enemy_Melee;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.PullWeapon();

        attackMoveSpeed = enemy.attackData.moveSpeed;
        enemy._animator.SetFloat("AttackAnimationSpeed", enemy.attackData.animationSpeed);
        enemy._animator.SetFloat("AttackIndex", enemy.attackData.attackIndex);


        enemy.agent.isStopped = true;
        enemy.agent.velocity = Vector3.zero;

        attackDirection = enemy.transform.position + (enemy.transform.forward * MAX_ATTACK_DISTANCE);
    }

    public override void Exit()
    {
        base.Exit();
        SetupNextAttack();
    }

    private void SetupNextAttack()
    {
        int recoveryIndex = PlayerClose() ? 1 : 0;
        enemy._animator.SetFloat("RecoveryIndex", recoveryIndex);

        enemy.attackData = UpdateAttackData();
    }

    public override void Update()
    {
        base.Update();
        if (enemy.ManualRotationActive())
        {
            enemy.transform.rotation = enemy.FaceTarget(enemy.player.position);
            attackDirection = enemy.transform.position + (enemy.transform.forward * MAX_ATTACK_DISTANCE);
        }

        if (enemy.ManualMovementActive())
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, attackDirection, attackMoveSpeed * Time.deltaTime);
        }

        if (triggerCalled)
        {
            _stateMachine.ChangeState(enemy.recoveryState);
        }
    }
    private bool PlayerClose() => Vector3.Distance(enemy.transform.position, enemy.player.position) <= 1;
    private AttackData UpdateAttackData() 
    {
        List<AttackData> validAttacks = new List<AttackData>(enemy.attackList);

        if (PlayerClose())
        {
            validAttacks.RemoveAll(parameter => parameter.attackType == AttackType_Melee.Charge);
        }
        int random = Random.Range(0, validAttacks.Count);
        return validAttacks[random];
    }
}
