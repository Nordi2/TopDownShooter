using Assets.CodeBase.Logic.EnemySamurai.StateSamurai;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Logic.EnemySamurai
{
    [System.Serializable]
    public struct AttackData
    {
        public string AttackName;
        public float AttackRange;
        public float MoveSpeed;
        public float AttackIndex;
        [Range(1, 2)]
        public float AnimationSpeed;
        public Attack_Melee _AttackMelee;
    }
    public enum Attack_Melee
    {
        Close,
        Charge,
    }
    public class EnemySamurai_Melee : EnemySamurai
    {
        public AppearanceIndleState_Samurai AppearanceState { get; private set; }
        public WalkState_Samurai WalkState { get; private set; }
        public IntroductionState_Samurai IntroductionState { get; private set; }
        public ChaseState_Samurai ChaseState { get; private set; }
        public AttackState_Samurai AttackState { get; private set; }
        [Header("Attack Data")]
        public AttackData AttackData;
        public List<AttackData> AttackList;
        protected override void Awake()
        {
            base.Awake();
            AppearanceState = new AppearanceIndleState_Samurai(this, StateMachine, "Apperance");
            WalkState = new WalkState_Samurai(this, StateMachine, "Walk");
            IntroductionState = new IntroductionState_Samurai(this, StateMachine, "Introduction");
            ChaseState = new ChaseState_Samurai(this, StateMachine, "Run");
            AttackState = new AttackState_Samurai(this, StateMachine, "Attack");
        }
        protected override void Start()
        {
            base.Start();
            StateMachine.Initialize(AppearanceState);
        }
        protected override void Update()
        {
            base.Update();
            StateMachine.CurrentState.Update();
        }
    }
}