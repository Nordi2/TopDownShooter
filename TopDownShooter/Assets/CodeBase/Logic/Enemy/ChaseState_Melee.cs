using UnityEngine;

namespace Assets.CodeBase.Logic.Enemy
{
    public class ChaseState_Melee : EnemyState
    {
        private Enemy_Melee enemy;
        private float lastTimeUpdateDistanation;

        public ChaseState_Melee(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
        {
            enemy = enemyBase as Enemy_Melee;
        }

        public override void Enter()
        {
            base.Enter();
            enemy.agent.speed = enemy.chaseSpeed;
            enemy.agent.isStopped = false;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (enemy.PlayerInAttackRange())
            {
                _stateMachine.ChangeState(enemy.attackState);
            }
            enemy.transform.rotation = enemy.FaceTarget(GetNextPathPoint());

            if (CanUpdateDestination())
            {
                enemy.agent.destination = enemy.player.transform.position;
            }
        }
        private bool CanUpdateDestination() 
        {
            if (Time.time > lastTimeUpdateDistanation + 0.25f)
            {
                lastTimeUpdateDistanation = Time.time;
                return true;
            }
            return false;
        }
    }
}