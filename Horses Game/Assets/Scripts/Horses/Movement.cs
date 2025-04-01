using UnityEngine;
using UnityEngine.AI;
using Utility;

namespace Horses
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Movement : MonoBehaviour
    {
        public bool IsMoving = false;

        private NavMeshAgent _agent;
        private Animator _animatorCmp;
        private Vector3 _moveVector;
        private Vector3 _originalForwardVector;
        private bool _clampAnimatorSpeedAgain = false;

        public NavMeshAgent Agent => _agent;

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

        private void Update()
        {
            MovementAnimator();
        }

        public void MoveAgentByMoveOffset(Vector3 offset)
        {
            _agent.Move(offset);

            IsMoving = true;
        }

        public void UpdateAgentSpeed(float newSpeed, bool shouldClampSpeed)
        {
            _agent.speed = newSpeed;

            _clampAnimatorSpeedAgain = shouldClampSpeed;
        }

        private void MovementAnimator()
        {
            float speed = _animatorCmp.GetFloat(Constants.ANIMATOR_SPEED_ANIMATOR_PARAM);

            float smoothering = Time.deltaTime * _agent.acceleration;

            if ( IsMoving )
            {
                speed += smoothering;
            }

            else
            {
                speed -= smoothering;
            }

            speed = Mathf.Clamp01( speed );

            _animatorCmp.SetFloat(Constants.ANIMATOR_SPEED_ANIMATOR_PARAM, speed);
        }
    }
}