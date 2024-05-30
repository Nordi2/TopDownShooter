using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Logic.EnemyZombie
{
    [System.Serializable]
    public struct AttackData 
    {
        public string AttackName;
        public float AttackRange;
        public float MoveSpeed;
        public float AttackIndex;
        [Range(1,2)]
        public float AnimationSpeed;
        public AttackType_Melee AttackType;
    }
    public enum AttackType_Melee { Close,Charge}
    public class EnemyZombie_Melee : Enemy
    {
        public ResurrectionState_ZombieMelee ResurrectionState { get; private set; }
        public GetUpState_ZombieMelee GetUpState { get; private set; }
        public MoveState_ZombieMelee MoveState { get; private set; }
        public AttackState_ZombieMelee AttackState { get; private set; }
        public RecoveryState_ZombieMelee RecoveryState { get; private set; }
        public DeadState_ZombieMelee DeadState { get; private set; }

        [Header("Attack Data")]
        public AttackData AttackData;
        public List<AttackData> AttackList;
        protected override void Awake()
        {
            base.Awake();
            ResurrectionState = new ResurrectionState_ZombieMelee(this, StateMachine, "Resurection");
            GetUpState = new GetUpState_ZombieMelee(this, StateMachine, "GetUp");
            MoveState = new MoveState_ZombieMelee(this, StateMachine, "Move");
            AttackState = new AttackState_ZombieMelee(this, StateMachine, "Attack");
            RecoveryState = new RecoveryState_ZombieMelee(this, StateMachine, "Recovery");
            DeadState = new DeadState_ZombieMelee(this, StateMachine, "Resurection");
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
        public override void GetHit()
        {
            StateMachine.ChangeState(DeadState);
        }
        public bool PlayerInAtackRange() => Vector3.Distance(transform.position, _player.position) < AttackData.AttackRange;
        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            Gizmos.DrawWireSphere(transform.position, AttackData.AttackRange);
        }
    }
}