using UnityEngine;
using UnityEngine.AI;

namespace Assets.CodeBase.Logic.Enemy
{
    public class ExampleEnemy : MonoBehaviour
    {
        public NavMeshAgent Agent;
        public Transform Target;

        private void Update()
        {
            Agent.destination = Target.position;
        }
    }
}