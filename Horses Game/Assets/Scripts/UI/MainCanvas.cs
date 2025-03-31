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
        }

        private void OnDisable()
        {
            EventManager.OnShowTimeInMainCanvas -= HandleOnShowTimeInMainCanvas;
        }

        private void HandleOnShowTimeInMainCanvas(float time)
        {
            _text.text = time.ToString("0");
        }
    }
}