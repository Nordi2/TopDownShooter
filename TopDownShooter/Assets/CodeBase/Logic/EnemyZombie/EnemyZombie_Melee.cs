using Assets.CodeBase.Logic.EnemyZombie;

public class EnemyZombie_Melee : Enemy
{
    public IdleState_ZombieMelee IdleState { get; private set; }
    public MoveState_ZombieMelee MoveState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        IdleState = new IdleState_ZombieMelee(this, StateMachine, "Idle");
        MoveState = new MoveState_ZombieMelee(this, StateMachine, "Move");
    }
    protected override void Start()
    {
        base.Start();
        StateMachine.Initialize(IdleState);
    }
    protected override void Update()
    {
        base.Update();
        StateMachine.CurrentState.Update();
    }

}
