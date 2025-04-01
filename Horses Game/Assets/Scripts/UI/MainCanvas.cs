using Core;
using TMPro;
using UnityEngine;

namespace UI
{
    public class MainCanvas : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            EventManager.OnShowTimeInMainCanvas += HandleOnShowTimeInMainCanvas;
            EventManager.OnHorsesStartRun += HandleOnHorsesStartRun;
            EventManager.OnAllHorsesFinish += HandleOnAllHorsesFinish;
        }

        private void OnDisable()
        {
            EventManager.OnShowTimeInMainCanvas -= HandleOnShowTimeInMainCanvas;
            EventManager.OnHorsesStartRun -= HandleOnHorsesStartRun;
            EventManager.OnAllHorsesFinish -= HandleOnAllHorsesFinish;
        }

        private void HandleOnShowTimeInMainCanvas(float time)
        {
            _text.text = time.ToString("0");
        }

        private void HandleOnHorsesStartRun()
        {
            _text.enabled = false;
        }

        private void HandleOnAllHorsesFinish()
        {

        }
    }
}