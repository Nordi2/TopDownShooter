namespace Assets.CodeBase.Logic.EnemyZombie
{
    public class EnemyState
    {
        protected Enemy _enemyBase;
        protected EnemyStateMachine _stateMachine;

        protected string _animBoolName;
        protected bool _triggerCalled;
        public EnemyState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBollName)
        {
            _enemyBase = enemyBase;
            _stateMachine = stateMachine;
            _animBoolName = animBollName;
        }
        public virtual void Enter()
        {
            _enemyBase.Animator.SetBool(_animBoolName, true);
            _triggerCalled = false;
        }
        public virtual void Update()
        {
        }
        public virtual void Exit()
        {
            _enemyBase.Animator.SetBool(_animBoolName, false);
        }
        public void AnimationTrigger() => _triggerCalled = true;
    }
}