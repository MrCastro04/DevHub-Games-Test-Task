using Core;
using Horses;
using TMPro;
using UnityEngine;

namespace UI.Canvas_Components
{
    public class SpeedContainerController : MonoBehaviour
    {
        private HorseContoller _thisHorse;
        private TextMeshProUGUI _speedText;

        private void Awake()
        {
            _speedText = GetComponentInChildren<TextMeshProUGUI>();

            _thisHorse = GetComponentInParent<HorseContoller>();
        }

        private void OnEnable()
        {
        EventManager.OnShowSpeedBuffValue += HandleOnShowSpeedBuffValue;
        }

        private void OnDisable()
        {
            EventManager.OnShowSpeedBuffValue -= HandleOnShowSpeedBuffValue;
        }

        private void HandleOnShowSpeedBuffValue(HorseContoller horse,int min ,int max)
        {
            if(horse != _thisHorse) return;

            _speedText.text = $"{min} - {max}";
        }
    }
}