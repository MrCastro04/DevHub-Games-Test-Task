using Core;
using Horses;
using TMPro;
using UnityEngine;
using System.Collections;

namespace UI.Canvas_Components
{
    public class SpeedContainerController : MonoBehaviour
    {
        private HorseContoller _thisHorse;
        private TextMeshProUGUI _speedText;
        private bool _valueReceived = false;

        private void Awake()
        {
            _speedText = GetComponentInChildren<TextMeshProUGUI>();
            _thisHorse = GetComponentInParent<HorseContoller>();
        }

        private void Start()
        {
            StartCoroutine(CheckForSpeedValues());
        }

        private void OnEnable()
        {
            EventManager.OnShowSpeedBuffValue += HandleOnShowSpeedBuffValue;
        }

        private void OnDisable()
        {
            EventManager.OnShowSpeedBuffValue -= HandleOnShowSpeedBuffValue;
        }

        private IEnumerator CheckForSpeedValues()
        {
            yield return new WaitForSeconds(0.2f);

            if (!_valueReceived && _thisHorse != null && _thisHorse.HorseMINSpeedBuffValue > 0)
            {
                _speedText.text = $"{_thisHorse.HorseMINSpeedBuffValue} - {_thisHorse.HorseMAXSpeedBuffValue}";
                _valueReceived = true;
            }
        }

        private void HandleOnShowSpeedBuffValue(HorseContoller horse, int min, int max)
        {
            if(horse != _thisHorse) return;

            _speedText.text = $"{min} - {max}";
            _valueReceived = true;
        }
    }
}