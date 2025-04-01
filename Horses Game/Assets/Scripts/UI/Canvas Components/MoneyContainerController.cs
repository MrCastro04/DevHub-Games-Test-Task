using Core;
using Horses;
using TMPro;
using UnityEngine;

namespace UI.Canvas_Components
{
    public class MoneyContainerController : MonoBehaviour
    {
        private HorseContoller _thisHorse;
        private TextMeshProUGUI _moneyText;

        private void Awake()
        {
            _moneyText = GetComponentInChildren<TextMeshProUGUI>();

            _thisHorse = GetComponentInParent<HorseContoller>();
        }

        private void OnEnable()
        {
            EventManager.OnShowMoneyValueForHorse += HandleOnShowMoneyValueForHorse;
        }

        private void OnDisable()
        {
            EventManager.OnShowMoneyValueForHorse -= HandleOnShowMoneyValueForHorse;
        }

        private void HandleOnShowMoneyValueForHorse(HorseContoller horse,int moneyValue)
        {
            if(horse != _thisHorse) return;

            _moneyText.text = moneyValue.ToString();
        }
    }
}