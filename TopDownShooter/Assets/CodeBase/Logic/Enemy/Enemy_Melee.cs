using Assets.CodeBase.Logic.Enemy;
using UnityEngine;

public class Enemy_Melee : Enemy
{
    public IdleState_Melee IdleState { get; private set; }
    public MoveState_Melee MoveState { get; private set; }
    public RecoveryState_Melee recoveryState { get; private set; }
    public ChaseState_Melee chaseState { get; private set; }
    public AttackState_Melee attackState { get; private set; }

    [SerializeField] private Transform hiddenWeapon;
    [SerializeField] private Transform pulledWeapon;
    protected override void Awake()
    {
        base.Awake();

        IdleState = new IdleState_Melee(this, stateMachine, "Idle");
        MoveState = new MoveState_Melee(this, stateMachine, "Move");
        recoveryState = new RecoveryState_Melee(this, stateMachine, "Recovery");
        chaseState = new ChaseState_Melee(this, stateMachine, "Chase");
        attackState = new AttackState_Melee(this, stateMachine, "Attack");
    }
    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(IdleState);
    }
    protected override void Update()
    {
        base.Update();
        stateMachine.CurrentState.Update();
    }
    public void PullWeapon() 
    {
        hiddenWeapon.gameObject.SetActive(false);
        pulledWeapon.gameObject.SetActive(true);
    }
}
