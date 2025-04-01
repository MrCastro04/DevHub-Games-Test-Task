using Core;
using TMPro;
using UnityEngine;
using Utility;

namespace UI.Canvas_Components
{
    public class PlayerMoneyInfoContainer : MonoBehaviour
    {
        private TextMeshProUGUI _moneyText;

        private void Awake()
        {
            _moneyText =
                GameObject.FindGameObjectWithTag(Constants.MONEY_TEXT_TAG)
                .GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            EventManager.OnPlayerGetMoney += HandleOnPlayerGetMoney;
        }

        private void OnDisable()
        {
            EventManager.OnPlayerGetMoney -= HandleOnPlayerGetMoney;
        }

        private void HandleOnPlayerGetMoney(int moneyValue)
        {
            _moneyText.text = moneyValue.ToString();
        }
    }
}