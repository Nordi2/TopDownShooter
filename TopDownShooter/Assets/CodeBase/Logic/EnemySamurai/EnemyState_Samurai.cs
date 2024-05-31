using UnityEngine;

namespace Assets.CodeBase.Logic.EnemySamurai
{
    public class EnemyState_Samurai
    {
        protected EnemySamurai _enemyBase;
        protected EnemyStateMachine_Samurai _stateMachine;

        protected string _animBollName;
        protected bool _triggerCalled;
        public EnemyState_Samurai(EnemySamurai enemyBase,EnemyStateMachine_Samurai stateMachine,string animBollName)
        {
            _enemyBase = enemyBase;
            _stateMachine = stateMachine;
            _animBollName = animBollName;

        }
        public virtual void Enter()
        {
            _enemyBase.Animator.SetBool(_animBollName, true);
            _triggerCalled = false;
        }
        public virtual void Update() 
        {
        }
        public virtual void Exit()
        {
            _enemyBase.Animator.SetBool(_animBollName, false);
        }
        public void AnimationTrigger() => _triggerCalled = true;
    }
}