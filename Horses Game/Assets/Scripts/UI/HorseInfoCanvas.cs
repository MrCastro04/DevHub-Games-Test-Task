using Core;
using UnityEngine;

namespace UI
{
    public class HorseInfoCanvas : MonoBehaviour
    {
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }

        private void Start()
        {
            if (_canvas.enabled == false)
            {
                _canvas.enabled = true;
            }
        }

        private void OnEnable()
        {
            EventManager.OnHorsesStartRun += HandleOnHorsesStartRun;
        }

        private void OnDisable()
        {
            EventManager.OnHorsesStartRun -= HandleOnHorsesStartRun;
        }

        private void HandleOnHorsesStartRun()
        {
            _canvas.enabled = false;
        }
    }
}