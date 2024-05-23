using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.Logic.Enemy
{
    public class MoveState_Melee : EnemyState
    {
        private Enemy_Melee enemy;
        private Vector3 _destination;
        public MoveState_Melee(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
        {
            enemy = enemyBase as Enemy_Melee;
        }

        public override void Enter()
        {
            base.Enter();

            enemy.agent.speed = enemy.moveSpeed;

            _destination = enemy.GetPatrolDestination();
            enemy.agent.SetDestination(_destination);
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

            enemy.transform.rotation = enemy.FaceTarget(GetNextPathPoint());
            if (enemy.agent.remainingDistance <= enemy.agent.stoppingDistance + 0.5f)
            {
                _stateMachine.ChangeState(enemy.IdleState);
            }
        }
    }
}


