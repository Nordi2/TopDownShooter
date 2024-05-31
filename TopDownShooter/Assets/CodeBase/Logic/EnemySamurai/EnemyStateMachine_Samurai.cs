namespace Assets.CodeBase.Logic.EnemySamurai
{
    public class EnemyStateMachine_Samurai 
    {
       public EnemyState_Samurai CurrentState { get; private set; }

        public void Initialize(EnemyState_Samurai startState)
        {
            CurrentState = startState;
            CurrentState.Enter();
        }
        public void ChangeState(EnemyState_Samurai newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}