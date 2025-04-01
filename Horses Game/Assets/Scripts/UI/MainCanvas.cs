using Core;
using TMPro;
using UnityEngine;
using Utility;

namespace UI
{
    public class MainCanvas : MonoBehaviour
    {
        private TextMeshProUGUI _startTimerText;

        private void Awake()
        {
            _startTimerText =
                GameObject.FindGameObjectWithTag(Constants.START_TIMER_TEXT_TAG)
                .GetComponent<TextMeshProUGUI>();
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
            _startTimerText.text = time.ToString("0");
        }

        private void HandleOnHorsesStartRun()
        {
            _startTimerText.enabled = false;
        }

        private void HandleOnAllHorsesFinish()
        {
          Debug.Log("All Horses Finish");
        }
    }
}