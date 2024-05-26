using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.Logic.EnemyZombie
{
    public class Enemy : MonoBehaviour
    {
        public Transform _player;
        [Header("Move data")]
        public float MoveSpeed;
        public NavMeshAgent Agent { get; private set; }
        public Animator Animator { get; private set; }
        public EnemyStateMachine StateMachine { get; private set; }
        private bool _isGetUp;
        private bool _isMoveResurection;
        private bool _isResurect;
        protected virtual void Awake()
        {
            StateMachine = new EnemyStateMachine();
            Agent = GetComponent<NavMeshAgent>();
            Animator = GetComponentInChildren<Animator>();
        }
        protected virtual void Start()
        {
            InitializePatrolPoints();
        }

        private void InitializePatrolPoints()
        {
        }

        protected virtual void Update()
        {

        }
        public bool IsGetUp() =>
            _isGetUp;
        public void GetUp() =>
            _isGetUp = true;
        public void ActivayeMoveResurection(bool moveResurect) =>
            _isMoveResurection = moveResurect;
        public bool MovementResurectActive() =>
            _isMoveResurection;
        public void ActivateResurect(bool resurect) =>
            _isResurect = resurect;
        public bool ResurectActive() => _isResurect;
    }
}