using UnityEngine;
using UnityEngine.AI;

namespace Horses
{
    [RequireComponent(typeof(Patrol))]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Movement))]
    public class HorseContoller : MonoBehaviour
    {
        public readonly AIFinishState FinishState = new();
        public readonly AIPatrolState PatrolState = new();

        private AIBaseState _currentState;

        public NavMeshAgent Agent { get; private set; }
        public Patrol Patrol { get; private set; }
        public Movement Movement { get; private set; }

        private void Awake()
        {
            _currentState = PatrolState;
            
            Agent = GetComponent<NavMeshAgent>();

            Patrol = GetComponent<Patrol>();

            Movement = GetComponent<Movement>();
        }

        private void Start()
        {
            _currentState.EnterState(this);
        }

        private void Update()
        {
            _currentState.UpdateState(this);
        }

        private void SwitchState(AIBaseState newState)
        {
            _currentState = newState;

            _currentState.EnterState(this);
        }
    }
}
