using TMPro;
using UnityEngine;

namespace UI.Canvas_Components
{
    public class MoneyContainerController : MonoBehaviour
    {
        private TextMeshProUGUI _moneyText;

        private void Awake()
        {
            _moneyText = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }


    }
}