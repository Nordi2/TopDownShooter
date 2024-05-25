using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.Logic.Enemy
{
    public class Enemy : MonoBehaviour
    {
        public float turnSpeed;
        public float aggresionRange;


        [Header("Idle Info")]
        public float idleTime;
        [Header("Move data")]
        public float moveSpeed;
        public float chaseSpeed;
        private bool manualMovement;
        private bool manualRotation;

        [SerializeField] private Transform[] patrolPoints;
        private int currentPatrolIndex;

        public Transform player { get; private set; }
        public Animator _animator { get; private set; }

        public NavMeshAgent agent { get; private set; }
        public EnemyStateMachine stateMachine { get; private set; }
        protected virtual void Awake() 
        {
            stateMachine = new EnemyStateMachine();
            agent = GetComponent<NavMeshAgent>();
            _animator = GetComponentInChildren<Animator>();
            player = GameObject.Find("Player").GetComponent<Transform>();
        }
        protected virtual void Start()
        {
            InitializePatrolPoints();
        }

        protected virtual void Update() 
        {

        }
        public void ActivateManualMovement(bool manualMovement) => this.manualMovement = manualMovement;
        public bool ManualMovementActive() => manualMovement;
        public void ActivateManualRotation(bool manualRotation) => this.manualRotation = manualRotation;
        public bool ManualRotationActive() => manualRotation;

        public void AnimationTrigger() => stateMachine.CurrentState.AnimationTrigger();
        public bool PlayerInAggresionRange() => Vector3.Distance(transform.position, player.position) < aggresionRange;
        public Vector3 GetPatrolDestination() 
        {
            Vector3 destination = patrolPoints[currentPatrolIndex].transform.position;

            currentPatrolIndex++;
            if (currentPatrolIndex >= patrolPoints.Length)
            {
                currentPatrolIndex = 0;
            }
            return destination;
        }
        public Quaternion FaceTarget(Vector3 target)
        {
            Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);

            Vector3 currentEulerAngels = transform.rotation.eulerAngles;

            float yRotation = Mathf.LerpAngle(currentEulerAngels.y, targetRotation.eulerAngles.y, turnSpeed * Time.deltaTime);

            return Quaternion.Euler(currentEulerAngels.x, yRotation, currentEulerAngels.z);
        }
        private void InitializePatrolPoints()
        {
            foreach (Transform transform in patrolPoints)
            {
                transform.parent = null;
            }
        }
        protected virtual void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, aggresionRange);
        }
    }
}