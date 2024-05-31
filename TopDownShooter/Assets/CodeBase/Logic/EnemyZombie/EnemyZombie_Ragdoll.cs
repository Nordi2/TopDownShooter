using System;
using UnityEngine;

namespace Assets.CodeBase.Logic.EnemyZombie
{
    public class EnemyZombie_Ragdoll : MonoBehaviour
    {
        [SerializeField] private Transform _ragdollParent;

        [SerializeField] private Collider[] _ragdollColliders;
        [SerializeField] private Rigidbody[] _ragdollRigidboied;

        private void Awake()
        {
            _ragdollColliders = GetComponentsInChildren<Collider>();
            _ragdollRigidboied = GetComponentsInChildren<Rigidbody>();

             RagdollActive(false);
        }

        public void RagdollActive(bool active)
        {
            foreach (Rigidbody rigidbody in _ragdollRigidboied)
            {
                rigidbody.isKinematic = !active;
            }
        }
    }
}