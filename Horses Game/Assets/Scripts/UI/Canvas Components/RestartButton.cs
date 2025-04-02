using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
