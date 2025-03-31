using UnityEngine;
using UnityEngine.AI;
using Utility;

namespace Horses
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Movement : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Animator _animatorCmp;
        private Vector3 _moveVector;
        private Vector3 _originalForwardVector;
        private bool _isMoving = false;
        private bool _clampAnimatorSpeedAgain = false;

        public NavMeshAgent Agent => _agent;
        public Vector3 OriginalForwardVector => _originalForwardVector;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();

            _animatorCmp = GetComponentInChildren<Animator>();

            _originalForwardVector = transform.forward;
        }

        private void Start()
        {
            _agent.updateRotation = false;
        }

        public void MoveAgentByDestination(Vector3 destination)
        {
            _agent.SetDestination(destination);

            _isMoving = true;
        }

        public void StopMovingAgent()
        {
            _agent.ResetPath();

            _isMoving = false;
        }

        public bool ReachedDestination()
        {
            if (_agent.pathPending)
            {
                return false;
            }

            if (_agent.remainingDistance > _agent.stoppingDistance)
            {
                return false;
            }

            if (_agent.hasPath || _agent.velocity.sqrMagnitude != 0f)
            {
                return false;
            }

            return true;
        }

        public void MoveAgentByMoveOffset(Vector3 offset)
        {
            _agent.Move(offset);

            _isMoving = true;
        }

        public void UpdateAgentSpeed(float newSpeed, bool shouldClampSpeed)
        {
            _agent.speed = newSpeed;

            _clampAnimatorSpeedAgain = shouldClampSpeed;
        }

        public void Rotate(Vector3 newForwardVector)
        {
            if (newForwardVector == Vector3.zero)
            {
                return;
            }

            float normal = Time.deltaTime * _agent.angularSpeed;

            Quaternion startQuaternion = transform.rotation;

            Quaternion endQuaternion = Quaternion.LookRotation(newForwardVector);

            transform.rotation = Quaternion.Lerp(startQuaternion, endQuaternion, normal);
        }

        private void MovePlayer()
        {
            Vector3 offset = _moveVector * Time.deltaTime * _agent.speed;

            _agent.Move(offset);
        }
    }
}