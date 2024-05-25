public class EnemyStateMachine
{
    public Assets.CodeBase.Logic.Enemy.EnemyState CurrentState { get; private set; }
    public void Initialize(Assets.CodeBase.Logic.Enemy.EnemyState startState)
    {
        CurrentState = startState;
        CurrentState.Enter();
    }
    public void ChangeState(Assets.CodeBase.Logic.Enemy.EnemyState newState) 
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
