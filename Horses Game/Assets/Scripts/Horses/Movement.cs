using UnityEngine;
using UnityEngine.AI;
using Utility;

namespace Horses
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Movement : MonoBehaviour
    {
        public bool IsMoving = false;

        private Patrol _patrol;
        private NavMeshAgent _agent;
        private Animator _animator;
        private Vector3 _moveVector;

        private void Awake()
        {
            _patrol = GetComponentInParent<Patrol>();
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponentInChildren<Animator>();
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

        private void MovementAnimator()
        {
            float speed = _animator.GetFloat(Constants.ANIMATOR_SPEED_ANIMATOR_PARAM);

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

            _animator.SetFloat(Constants.ANIMATOR_SPEED_ANIMATOR_PARAM, speed);
        }
    }
}