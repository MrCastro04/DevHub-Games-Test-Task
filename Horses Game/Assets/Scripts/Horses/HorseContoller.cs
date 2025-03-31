using System;
using UnityEngine;
using UnityEngine.AI;

namespace Horses
{
    [RequireComponent(typeof(Patrol))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class HorseContoller : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public readonly AIFinishState FinishState = new();
        public readonly AIPatrolState PatrolState = new();

        private AIBaseState _currentState;
        private Patrol _patrolCmp;

        private void Awake()
        {
            _patrolCmp = GetComponent<Patrol>();
        }

        private void Start()
        {
            _currentState.EnterState(this);
        }

        private void Update()
        {
            _patrolCmp.CalculateNextPosition();
        }

        private void SwitchState(AIBaseState newState)
        {
            _currentState = newState;

            _currentState.EnterState(this);
        }
    }
}
