using Horses;
using UnityEngine;

namespace Core
{
    public class FinishMoneyCalculator : MonoBehaviour
    {
        private int _finishedHorseCount = 0;

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
            if (finishedHorse.IsChosenByPlayer && _finishedHorseCount == 0)
            {
                PlayerResources.Instance.EarnMoney(finishedHorse.HorseMoneyValue);
            }

            _finishedHorseCount++;
        }
    }
}