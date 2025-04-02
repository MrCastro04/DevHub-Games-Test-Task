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
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(HorseAudioController))]
    public class HorseContoller : MonoBehaviour
    {
        public readonly AIFinishState FinishState = new();
        public readonly AIPatrolState PatrolState = new();
        public readonly AIChooseState ChooseState = new();

        private static bool _globalChoiceConfirmed = false;
        private HorseAudioController _horseAudioController;
        private Rigidbody _rigidbody;
        private AIBaseState _currentState;
        private bool _hasSpeedBuffValues = false;
        private bool _hasChoose = true;
        private float _waitTime = 3f;
        private float _nextBuffPercent = 0.1f;

        public NavMeshAgent Agent { get; private set; }
        public Patrol Patrol { get; private set; }
        public Movement Movement { get; private set; }
        public bool IsChosenByPlayer { get; private set; } = false;
        public int HorseMoneyValue { get; private set; }
        public int HorseMINSpeedBuffValue { get; private set; }
        public int HorseMAXSpeedBuffValue { get; private set; }

        public float NextBuffPercent
        {
            get => _nextBuffPercent;
            set => _nextBuffPercent = value;
        }

        private void Awake()
        {
            _currentState = ChooseState;

            _horseAudioController = GetComponent<HorseAudioController>();

            _rigidbody = GetComponent<Rigidbody>();

            Agent = GetComponent<NavMeshAgent>();

            Patrol = GetComponent<Patrol>();

            Movement = GetComponent<Movement>();
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
            HorseMoneyValue = GenerateRandomHorseMoneyValue();

            StartCoroutine(DelayedSpeedValuesGeneration());

            _currentState.EnterState(this);
        }

        private IEnumerator DelayedSpeedValuesGeneration()
        {
            yield return null;

            GenerateHorseMINMAXSpeedValues();

            if (_hasSpeedBuffValues)
            {
                EventManager.RaiseOnShowSpeedBuffValue(this, HorseMINSpeedBuffValue, HorseMAXSpeedBuffValue);
            }
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

        public void ApplySpeedBuff()
        {
            var randomValue = Random.Range(HorseMINSpeedBuffValue, HorseMAXSpeedBuffValue);

            this.Agent.speed += randomValue;
        }

        private void OnMouseDown()
        {
            if (_hasChoose && !_globalChoiceConfirmed)
            {
                _hasChoose = false;

                _globalChoiceConfirmed = true;

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

        private int GenerateRandomHorseMoneyValue()
        {
            var value = Random.Range(1000, 100000);

            EventManager.RaiseOnShowMoneyValueForHorse(this, value);

            return value;
        }

        private int GenerateRandomHorseSpeedBuffValue()
        {
            var value = Random.Range(1, 10);

            return value;
        }

        private void GenerateHorseMINMAXSpeedValues()
        {
            if(_hasSpeedBuffValues) return;

            HorseMINSpeedBuffValue = GenerateRandomHorseSpeedBuffValue();

            HorseMAXSpeedBuffValue = GenerateRandomHorseSpeedBuffValue();

            if (HorseMINSpeedBuffValue >= HorseMAXSpeedBuffValue)
            {
                GenerateHorseMINMAXSpeedValues();
                return;
            }

            _hasSpeedBuffValues = true;

            EventManager.RaiseOnShowSpeedBuffValue(this, HorseMINSpeedBuffValue, HorseMAXSpeedBuffValue);
        }

        private void OnDestroy()
        {
            _globalChoiceConfirmed = false;
        }
    }
}