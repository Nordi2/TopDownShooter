using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Logic.EnemyZombie
{
    public class AttackState_ZombieMelee : EnemyState
    {
        private EnemyZombie_Melee _enemy;
        private Vector3 _attackDirection;
        private float _attackMoveSpeed;
        private const float MAX_ATTACK_DISTANCE = 50f;
        public AttackState_ZombieMelee(Enemy enemyBase, EnemyStateMachine stateMachine, string animBollName) : base(enemyBase, stateMachine, animBollName)
        {
            _enemy = enemyBase as EnemyZombie_Melee;
        }

        public override void Enter()
        {
            base.Enter();

            _attackMoveSpeed = _enemy.AttackData.MoveSpeed;
            _enemy.Animator.SetFloat("AttackAnimationSpeed", _enemy.AttackData.AnimationSpeed);
            _enemy.Animator.SetFloat("AttackIndex", _enemy.AttackData.AttackIndex);
            _enemy.Animator.SetFloat("SlashAttackIndex", Random.Range(0, 5));

            _enemy.Agent.isStopped = true;
            _enemy.Agent.velocity = Vector3.zero;

            _attackDirection = _enemy.transform.position + _enemy.transform.forward * MAX_ATTACK_DISTANCE;
        }

        public override void Exit()
        {
            base.Exit();
            _enemy.AttackData = UpdateAttackData();

            _enemy.Agent.isStopped = false;
        }

        public override void Update()
        {
            base.Update();
            if (_enemy.ManualRotationActive())
            {
                _enemy.transform.rotation = _enemy.FaceTarget(_enemy._player.position);
            }
            if (_enemy.ManualMovementActive())
            {
                _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _attackDirection, _attackMoveSpeed * Time.deltaTime);
            }
            if (_triggerCalled)
            {
                _enemy.StateMachine.ChangeState(_enemy.RecoveryState);
            }
            if (Vector3.Distance(_enemy.transform.position, _enemy._player.position) >= 1 && _triggerCalled)
            {
                _enemy.StateMachine.ChangeState(_enemy.MoveState);
            }
        }
        private bool PlayerClose() => Vector3.Distance(_enemy.transform.position, _enemy._player.position) <= 1f;
        private AttackData UpdateAttackData()
        {
            List<AttackData> validAttacks = new List<AttackData>(_enemy.AttackList);

            if (PlayerClose())
            {
                validAttacks.RemoveAll(parameter => parameter.AttackType == AttackType_Melee.Charge);
            }
            int random = Random.Range(0, validAttacks.Count);
            return validAttacks[random];
        }
    }
}