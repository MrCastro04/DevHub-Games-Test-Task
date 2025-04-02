using Core;
using TMPro;
using UnityEngine;
using Utility;
using System.Collections;

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

        private void Start()
        {
            if (PlayerResources.Instance != null)
            {
                HandleOnPlayerGetMoney(PlayerResources.Instance.Money);
            }
            else
            {
                StartCoroutine(WaitForPlayerResources());
            }
        }

        private IEnumerator WaitForPlayerResources()
        {
            while (PlayerResources.Instance == null)
            {
                yield return null;
            }

            HandleOnPlayerGetMoney(PlayerResources.Instance.Money);
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