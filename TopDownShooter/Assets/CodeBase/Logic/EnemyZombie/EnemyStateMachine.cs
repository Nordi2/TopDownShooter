namespace Assets.CodeBase.Logic.EnemyZombie
{
    public class EnemyStateMachine
    {
        public EnemyState CurrentState { get; private set; }

        public void Initialize(EnemyState startState)
        {
            CurrentState = startState;
            CurrentState.Exit();
        }
        public void ChangeState(EnemyState newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}