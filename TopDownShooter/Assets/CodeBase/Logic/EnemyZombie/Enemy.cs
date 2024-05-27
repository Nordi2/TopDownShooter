using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.Logic.EnemyZombie
{
    public class Enemy : MonoBehaviour
    {
        public float TurnSpeed;
        public Transform _player;
        [Header("Move data")]
        public float MoveSpeed;
        public NavMeshAgent Agent { get; private set; }
        public Animator Animator { get; private set; }
        public EnemyStateMachine StateMachine { get; private set; }
        private bool _manualMovement;
        private bool _manualRotation;
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
        public void ActivayeManualMovement(bool manualMovement) =>
            _manualMovement = manualMovement;
        public bool ManualMovementActive() =>
            _manualMovement;
        public void AnimationTrigger() =>
            StateMachine.CurrentState.AnimationTrigger();
        public bool ActivateManualRotation(bool manualRotation) =>
            _manualRotation = manualRotation;
        public bool ManualRotationActive() =>
            _manualRotation;
        public Quaternion FaceTarget(Vector3 target)
        {
            Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);
            Vector3 currentEulerAngles = transform.rotation.eulerAngles;

            float yRotation = Mathf.LerpAngle(currentEulerAngles.y, targetRotation.eulerAngles.y, TurnSpeed * Time.deltaTime);
            return Quaternion.Euler(currentEulerAngles.x, yRotation, currentEulerAngles.z);
        }
    }
}