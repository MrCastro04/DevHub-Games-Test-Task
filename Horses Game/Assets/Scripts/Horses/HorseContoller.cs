using System.Collections;
using Core;
using Horses.States;
using UnityEngine;
using UnityEngine.AI;
using Utility;

namespace Horses
{
    [RequireComponent(typeof(Patrol))]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Movement))]

    public class HorseContoller : MonoBehaviour
    {
        public readonly AIChargeState WinHorseState = new();
        public readonly AIFinishState FinishState = new();
        public readonly AIPatrolState PatrolState = new();
        public readonly AIChooseState ChooseState = new();

        private AIBaseState _currentState;
        private bool _canChoose = true;
        private bool _isWinHorse = false;
        private float _waitTime = 3f;

        public bool CanChoose => _canChoose;
        public WinHorseManager WinHorseManager { get; private set; }
        public NavMeshAgent Agent { get; private set; }
        public Patrol Patrol { get; private set; }
        public Movement Movement { get; private set; }
        public bool IsChosenByPlayer { get; private set; }

        private void Awake()
        {
            _currentState = ChooseState;

            Agent = GetComponent<NavMeshAgent>();

            Patrol = GetComponent<Patrol>();

            Movement = GetComponent<Movement>();

            WinHorseManager =
                GameObject.FindGameObjectWithTag(Constants.WIN_HORSE_MANAGER_TAG)
                .GetComponent<WinHorseManager>();
        }

        private void OnEnable()
        {
            EventManager.OnPlayerConfirmChoose += HandleOnPlayerConfirmChoose;
        }

        private void OnDisable()
        {
            EventManager.OnPlayerConfirmChoose -= HandleOnPlayerConfirmChoose;
        }

        private void Start()
        {
            _currentState.EnterState(this);
        }

        private void Update()
        {
            _currentState.UpdateState(this);
        }

        public void SwitchState(AIBaseState newState)
        {
            _currentState = newState;

            _currentState.EnterState(this);
        }

        public void SetThisHorseWinHorse()
        {
            _isWinHorse = true;
        }

        public bool IsWinHorse()
        {
            return _isWinHorse;
        }

        private void OnMouseDown()
        {
            if (_canChoose)
            {
                _canChoose = false;

                IsChosenByPlayer = true;

                MainCamera mainCamera =
                    GameObject.FindGameObjectWithTag(Constants.MAIN_CAMERA_TAG)
                    .GetComponent<MainCamera>();

                mainCamera.AttachCameraToConfirmedHorse(this);
            }
        }

        private void HandleOnPlayerConfirmChoose()
        {
            StartCoroutine(WaitTimeAndRun(_waitTime));
        }

        private IEnumerator WaitTimeAndRun(float time)
        {
            while (time > 0)
            {
                time -= Time.deltaTime;

                EventManager.RaiseOnShowTimeInMainCanvas(time);

                yield return null;
            }

            SwitchState(PatrolState);
        }
    }
}
