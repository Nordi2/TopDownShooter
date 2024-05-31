using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.Logic.EnemySamurai
{
    public class EnemySamurai : MonoBehaviour
    {
        [Header("Target")]
        public Transform Target;
        [Header("Agression Range")]
        public float AgressionRange;
        [Header("Attack Range")]
        public float AttackRange;
        [Header("Chase Speed")]
        public float ChaseSpeed;
        [Header("TurnSpeed")]
        public float TurnSpeed;

        [Header("Katatana")]
        [SerializeField] private Transform _hiddenWeapon;
        [SerializeField] private Transform _pulletWeapon;
        public NavMeshAgent Agent { get; private set; }
        public Animator Animator { get; private set; }
        public EnemyStateMachine_Samurai StateMachine { get; private set;}

        protected virtual void Awake()
        {
            StateMachine = new EnemyStateMachine_Samurai();
            Agent = GetComponent<NavMeshAgent>();
            Animator = GetComponentInChildren<Animator>();
        }
        protected virtual void Start() 
        {

        }
        protected virtual void Update() 
        {

        }
        public void AnimationTrigger() =>
            StateMachine.CurrentState.AnimationTrigger();
        public bool PlayerInAttackRange() => Vector3.Distance(transform.position, Target.position) <= AttackRange;
        public bool PlayerInAgresionRange() => Vector3.Distance(transform.position, Target.position) <= AgressionRange;
        public void PulletWeapon() 
        {
            _hiddenWeapon.gameObject.SetActive(false);
            _pulletWeapon.gameObject.SetActive(true);
        }
        public Quaternion FaceTarget(Vector3 target)
        {
            Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);

            Vector3 currentEulerAngels = transform.rotation.eulerAngles;

            float yRotation = Mathf.LerpAngle(currentEulerAngels.y, targetRotation.eulerAngles.y, TurnSpeed * Time.deltaTime);

            return Quaternion.Euler(currentEulerAngels.x, yRotation, currentEulerAngels.z);
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, AgressionRange);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, AttackRange);
        }
    }
}