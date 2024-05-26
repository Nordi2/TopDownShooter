namespace Assets.CodeBase.Logic.EnemyZombie
{
    public class EnemyZombie_Melee : Enemy
    {
        public ResurrectionState_ZombieMelee ResurrectionState { get; private set; }
        public GetUpState_ZombieMelee GetUpState { get; private set; }
        public MoveState_ZombieMelee MoveState { get; private set; }
        public AttackState_ZombieMelee AttackState { get; private set; }
        protected override void Awake()
        {
            base.Awake();
            ResurrectionState = new ResurrectionState_ZombieMelee(this, StateMachine, "Resurection");
            GetUpState = new GetUpState_ZombieMelee(this, StateMachine, "GetUp");
            MoveState = new MoveState_ZombieMelee(this, StateMachine, "Move");
            AttackState = new AttackState_ZombieMelee(this, StateMachine, "Attack");
        }
        protected override void Start()
        {
            base.Start();
            StateMachine.Initialize(ResurrectionState);
        }
        protected override void Update()
        {
            base.Update();
            StateMachine.CurrentState.Update();
        }

    }
}