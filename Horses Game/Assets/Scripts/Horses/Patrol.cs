using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Splines;

namespace Horses
{
    public class Patrol : MonoBehaviour
    {
        [SerializeField] private GameObject _splineGameObject;

        private SplineContainer _splineCmp;
        private NavMeshAgent _agent;
        private float _splineLength;
        private float _splineCurrentPosition = 0f;
        private float _lengthWalked = 0f;
        private bool _isWalking = true;

        private void Awake()
        {
            if (_splineGameObject == null)
            {
                Debug.LogWarning($"{name} does not have a spline");
            }

            _splineCmp = _splineGameObject.GetComponent<SplineContainer>();

            _splineLength = _splineCmp.CalculateLength();

            _agent = GetComponent<NavMeshAgent>();
        }

        public Vector3 GetNextPosition()
        {
            return _splineCmp.EvaluatePosition( _splineCurrentPosition );
        }

        public void CalculateNextPosition()
        {
            _lengthWalked += Time.deltaTime * _agent.speed;

            if (_lengthWalked > _splineLength)
            {
                _lengthWalked = 0f;
            }

            _splineCurrentPosition = Mathf.Clamp01(_lengthWalked / _splineLength);
        }
    }
}
