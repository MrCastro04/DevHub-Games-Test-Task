using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Splines;

namespace Horses
{
    public class Patrol : MonoBehaviour
    {
        [SerializeField] private GameObject _splineGameObject;

        private SplineContainer _spline;
        private NavMeshAgent _agent;
        private float _splineLength;
        private float _splineCurrentPosition = 0f;
        private float _lengthWalked = 0f;
        private bool _isWalking = true;

        public float SplineCurrentPosition => _splineCurrentPosition;
        public SplineContainer Spline => _spline;

        private void Awake()
        {
            _spline = _splineGameObject.GetComponent<SplineContainer>();

            _splineLength = _spline.CalculateLength();

            _agent = GetComponent<NavMeshAgent>();
        }

        public Vector3 GetNextPosition()
        {
            return _spline.EvaluatePosition( _splineCurrentPosition );
        }

        public void CalculateNextPosition()
        {
            _lengthWalked += Time.deltaTime * _agent.speed;

            _splineCurrentPosition = Mathf.Clamp01(_lengthWalked / _splineLength);
        }
    }
}
