using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Core;
using Core.Saves;

namespace UI.Canvas_Components
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Start()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _button.onClick.RemoveListener(OnClick);

            if (CurrentSaveManager.Instance != null && PlayerResources.Instance != null)
            {
                CurrentSaveManager.Instance.CurrentSave.Money = PlayerResources.Instance.Money;

                SaveSystem.SetData(CurrentSaveManager.Instance.CurrentSave);
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}