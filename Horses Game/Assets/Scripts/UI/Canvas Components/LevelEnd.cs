using Core;
using Horses;
using UnityEngine;

namespace UI.Canvas_Components
{
    public class LevelEnd : MonoBehaviour
    {
        [SerializeField] private FinishZone _finishZone;
        [SerializeField] private WinView _winView;
        [SerializeField] private LoseView _loseView;

        private void OnEnable()
        {
            EventManager.OnHorseGetsFinish += HandleOnHorseGetsFinish;
        }

        private void OnDisable()
        {
            EventManager.OnHorseGetsFinish -= HandleOnHorseGetsFinish;
        }

        private void HandleOnHorseGetsFinish(HorseContoller finishedHorse)
        {
            if (finishedHorse.IsChosenByPlayer && _finishZone.HorseQueue.Count == 0)
            {
                ShowWinCanvas();
            }

            else if (finishedHorse.IsChosenByPlayer && _finishZone.HorseQueue.Count != 0)
            {
                ShowLoseView();
            }
        }

        private void ShowWinCanvas()
        {
            _winView.Enable();
        }

        private void ShowLoseView()
        {
            _loseView.Enable();
        }
    }
}
