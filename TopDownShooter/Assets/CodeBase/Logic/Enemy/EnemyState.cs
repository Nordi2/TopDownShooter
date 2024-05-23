using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.Logic.Enemy
{
    public class EnemyState 
    {
        private readonly protected Enemy _enemyBase;
        private readonly protected EnemyStateMachine _stateMachine;

        protected string _animBoolName;
        protected float _stateTimer;
        protected bool triggerCalled;
        public EnemyState(Enemy enemyBase,EnemyStateMachine stateMachine,string animBoolName)
        {
            _enemyBase = enemyBase;
            _stateMachine = stateMachine;
            _animBoolName = animBoolName;
        }
        public virtual void Enter() 
        {
            _enemyBase._animator.SetBool(_animBoolName, true);

            triggerCalled = false;
        }
        public virtual void Update()
        {
            _stateTimer -= Time.deltaTime;
        }
        public virtual void Exit() 
        {
            _enemyBase._animator.SetBool(_animBoolName, false);
        }
        public void AnimationTrigger() => triggerCalled = true;
        protected Vector3 GetNextPathPoint()
        {
            NavMeshAgent agent = _enemyBase.agent;
            NavMeshPath path = agent.path;

            if (path.corners.Length < 2)
            {
                return agent.destination;
            }
            for (int i = 0; i < path.corners.Length; i++)
            {
                if (Vector3.Distance(agent.transform.position, path.corners[i]) < 1)
                {
                    return path.corners[i + 1];
                }
            }
            return agent.destination;
        }
    }
}