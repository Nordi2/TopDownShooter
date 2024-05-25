using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.Logic.EnemyZombie
{
    public class Enemy : MonoBehaviour
    {
        [Header("Idle info")]
        public float IdleTime;
        [Header("Move data")]
        public float MoveSpeed;

        [SerializeField] private Transform[] _patrolPoints;
        private int _currentPatrolIndex;
        public NavMeshAgent Agent { get; private set; }
        public EnemyStateMachine StateMachine { get; private set; }
        protected virtual void Awake()
        {
            StateMachine = new EnemyStateMachine();
            Agent = GetComponent<NavMeshAgent>();
        }
        protected virtual void Start()
        {
            InitializePatrolPoints();
        }

        private void InitializePatrolPoints()
        {
            foreach (Transform t in _patrolPoints)
            {
                t.parent = null;
            }
        }

        protected virtual void Update()
        {

        }
        public Vector3 GetPatrolDestination()
        {
            Vector3 destination = _patrolPoints[_currentPatrolIndex].transform.position;

            _currentPatrolIndex++;
            if (_currentPatrolIndex >= _patrolPoints.Length)
            {
                _currentPatrolIndex = 0;
            }
            return destination;
        }
    }
}